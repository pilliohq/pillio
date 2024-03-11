using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Pillio.People
{
    public interface IPatientAppService : ICrudAppService<
        PatientDto,     // Used to show patients
        Guid,           // Primary key of the patient entity
        PagedAndSortedResultRequestDto, // Used for paging/sorting
        CreateOrEditPatientDto> // Used to create/update a patient
    {
        // You can add additional methods specific to the patient service if needed.
    }
}
