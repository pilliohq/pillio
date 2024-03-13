using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace Pillio.Medications;

public class MedicationPlansAppService : PillioAppService, IMedicationPlansAppService
{
    private readonly IRepository<MedicationPlan, Guid> _medicationPlanRepository;
    // private readonly ICloudStorage _cloudStorage;

    private readonly IDataFilter _dataFilter;
    private readonly IRepository<Patient, Guid> _patientRepository;
    private readonly IRepository<CareHome, Guid> _careHomeRepository;
    private readonly IRepository<OrderProduct, Guid> _orderProductRepository;

    public MedicationPlansAppService(IRepository<MedicationPlan, Guid> medicationPlanRepository, IRepository<Patient, Guid> patientRepository, IRepository<CareHome, Guid> careHomeRepository, IRepository<OrderProduct, Guid> orderProductRepository, IDataFilter dataFilter)
    {
        _medicationPlanRepository = medicationPlanRepository;
        _patientRepository = patientRepository;
        _careHomeRepository = careHomeRepository;
        _orderProductRepository = orderProductRepository;
        _dataFilter = dataFilter;
    }

    public async Task<PagedResultDto<GetMedicationPlanProductForViewDto>> GetMedicationProducts(GetAllMedicationPlanProductsInput input)
    {
        using var disableTenant = _dataFilter.Disable<IMultiTenant>();
        var careHome = (await _careHomeRepository.GetQueryableAsync())
           .Where(x => x.CareHomeTenantId == CurrentTenant.Id).FirstOrDefault();

        var filteredOrderProducts = (await _orderProductRepository.GetQueryableAsync())
            .Include(x => x.MedicationPlanProduct)
            .Include(x => x.MedicationPlanProduct).ThenInclude(x => x.Product)
            .Where(x => x.MedicationOrder.IsCurrentOrder)
            .WhereIf(careHome != null, x => x.MedicationOrder.NurseId == CurrentUser.Id)
            .WhereIf(careHome == null, x => x.MedicationOrder.MedicationPlan.PharmacyTenantId == CurrentTenant.Id)
            .WhereIf(input.IsFilling == true, x => x.AvailableCount <= 14)
            .WhereIf(input.IsWaitingPrescription == true, x => x.PrescriptionStatus == PrescriptionStatus.Required)
            .WhereIf(input.IsWaitingForDelivery == true, x => x.MedicationOrder.Status == OrderStatus.Confirmed)
            .WhereIf(input.IsDelivery == true, x => x.MedicationOrder.Status == OrderStatus.Delivery)
            .WhereIf(input.IsWaitingConfirmation == true, x => x.MedicationOrder.Status == OrderStatus.Processing || x.MedicationOrder.Status == OrderStatus.PriorityProcessing);

        var totalCount = await filteredOrderProducts.CountAsync();

        var pagedAndFilteredMedicationPlanProducts = filteredOrderProducts
            .OrderBy(input.Sorting ?? "id asc")
            .PageBy(input);

        var medicationPlanProducts = from o in pagedAndFilteredMedicationPlanProducts
                                     select new
                                     {
                                         MedicationPlanId = o.MedicationOrder.MedicationPlanId,
                                         o.UsedCount,
                                         o.Count,
                                         o.StartDate,
                                         o.MedicationPlanProduct.Frequency,
                                         o.MedicationPlanProduct.BillPack,
                                         o.MedicationPlanProduct.ExactlySamePrescription,
                                         o.MedicationPlanProduct.Notes,
                                         o.MedicationPlanProduct.WeeklyFrequencyDays,
                                         o.CurrentBatchEndDate,
                                         o.PrescriptionStatus,
                                         o.MedicationPlanProduct.ProductName,
                                         o.MedicationPlanProduct.DosingSchedule1Value,
                                         o.MedicationPlanProduct.DosingSchedule2Value,
                                         o.MedicationPlanProduct.DosingSchedule3Value,
                                         o.MedicationPlanProduct.DosingSchedule4Value,
                                         Id = o.Id,
                                         //o.MedicationOrder.Status,
                                     };


        var dbList = await medicationPlanProducts.ToListAsync();
        var results = new List<GetMedicationPlanProductForViewDto>();

        var medicationPlanIds = dbList.Select(x => x.MedicationPlanId).Distinct().ToList();
        var medicationPlans = await (await _medicationPlanRepository.GetQueryableAsync())
            .Include(x => x.Patient).ThenInclude(x => x.Avatar)
            .Include(x => x.CurrentOrder)
            .Where(x => medicationPlanIds.Contains(x.Id))
            .ToListAsync();

        foreach (var o in dbList)
        {
            var medicationPlan = medicationPlans.FirstOrDefault(x => x.Id == o.MedicationPlanId);
            var res = new GetMedicationPlanProductForViewDto()
            {
                MedicationPlanProduct = new MedicationPlanProductDto
                {
                    MedicationPlanId = o.MedicationPlanId,
                    PatientId = medicationPlan?.PatientId,
                    PatientName = medicationPlan?.Patient?.FullName,
                    UsedCount = o.UsedCount,
                    Count = o.Count,
                    StartDate = o.StartDate,

                    //Status = o.Status,
                    Frequency = o.Frequency,
                    BillPack = o.BillPack,
                    ExactlySamePrescription = o.ExactlySamePrescription,
                    Notes = o.Notes,
                    WeeklyFrequencyDays = o.WeeklyFrequencyDays,
                    CurrentBatchEndDate = o.CurrentBatchEndDate ?? System.DateTime.MaxValue,

                    PrescriptionStatus = o.PrescriptionStatus,
                    ProductName = o.ProductName,
                    DosingSchedule1Value = o.DosingSchedule1Value,
                    DosingSchedule2Value = o.DosingSchedule2Value,
                    DosingSchedule3Value = o.DosingSchedule3Value,
                    DosingSchedule4Value = o.DosingSchedule4Value,
                    Id = o.Id
                },
                OrderStatus = medicationPlan?.CurrentOrder?.Status ?? OrderStatus.Active,
                ProductName = o.ProductName,
                DeliveryDate = medicationPlan?.CurrentOrder?.DeliveryDate,
                OrderWorkflow = medicationPlan?.CurrentOrder?.Workflow
            };
            if (medicationPlan?.Patient?.Avatar != null)
            {
                // res.PatientAvatarUrl = _cloudStorage.GetPublicFileUrl(medicationPlan.Patient.Avatar.CloudFileId.ToString(), medicationPlan.Patient.Avatar.FileExtension);
            }

            results.Add(res);
        }
        var existedPatientIds = results.Select(x => x.MedicationPlanProduct.PatientId).Distinct().ToList();
        var careHomeId = careHome?.Id ?? null;
        var patients = await (await _patientRepository.GetQueryableAsync())
            .Include(x => x.Avatar).Include(x => x.Pharmacy)
            .Where(x => !x.IsDeleted && x.CareHomeId == careHomeId && !existedPatientIds.Contains(x.Id))
            .ToListAsync();
        foreach (var patient in patients)
        {
            // var avatarUrl = patient.Avatar != null ? _cloudStorage.GetPublicFileUrl(patient.Avatar?.CloudFileId.ToString(), patient.Avatar.FileExtension) : null;
            results.Add(new GetMedicationPlanProductForViewDto
            {
                MedicationPlanPatientName = patient.FullName,
                // PatientAvatarUrl = avatarUrl,
                ResponsiblePerson = patient.Pharmacy.Name,
                MedicationPlanProduct = new MedicationPlanProductDto() { PatientName = patient.FullName, PatientId = patient.Id }
            });
        }
        return new PagedResultDto<GetMedicationPlanProductForViewDto>(totalCount, results);

    }

}