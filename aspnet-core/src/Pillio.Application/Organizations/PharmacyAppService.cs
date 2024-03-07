using Pillio.Organizations.Pharmacies;
using Pillio.Organizations.Pharmacies.Dtos;
using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Pillio.Organizations
{
    public class PharmacyAppService : CrudAppService<
            Pharmacy, // The Pharmacy entity
            PharmacyDto, // Used to show pharmacies
            Guid, // Primary key of the pharmacy entity
            PagedAndSortedResultRequestDto, // Used for paging/sorting
            CreateOrEditPharmacyDto>, // Used to create/update a pharmacy
            IPharmacyAppService
    {
        public PharmacyAppService(IRepository<Pharmacy, Guid> repository) : base(repository)
        {
        }
    }
}
