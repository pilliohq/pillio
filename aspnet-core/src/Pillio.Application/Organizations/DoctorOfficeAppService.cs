using Pillio.Organizations.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Pillio.Organizations
{
    public class DoctorOfficeAppService : CrudAppService<
            DoctorOffice, // The DoctorOffice entity
            DoctorOfficeDto, // Used to show doctor offices
            Guid, // Primary key of the doctor office entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateOrEditDoctorOfficeDto>, // Used to create/update a doctor office
            IDoctorOfficeAppService
    {
        public DoctorOfficeAppService(IRepository<DoctorOffice, Guid> repository) : base(repository)
        {
        }
    }
}
