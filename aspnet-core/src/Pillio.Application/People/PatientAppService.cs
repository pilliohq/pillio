using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Pillio.People
{
    public class PatientAppService : CrudAppService<
            Patient, // The Patient entity
            PatientDto, // Used to show patients
            Guid, // Primary key of the patient entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateOrEditPatientDto>, // Used to create/update a patient
            IPatientAppService
    {
        public PatientAppService(IRepository<Patient, Guid> repository) : base(repository)
        {
        }
    }
}
