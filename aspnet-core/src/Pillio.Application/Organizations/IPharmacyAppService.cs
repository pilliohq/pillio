using Pillio.Organizations.Pharmacies.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations
{
    public interface IPharmacyAppService : ICrudAppService< // Defines CRUD methods
            PharmacyDto, // Used to show pharmacies
            Guid, // Primary key of the pharmacy entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateOrEditPharmacyDto> // Used to create/update a pharmacy
    {

    }
}
