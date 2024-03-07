
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Pharmacies.Dtos
{
    public class GetAllPharmaciesInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public string? NameFilter { get; set; }

        public string? AddressFilter { get; set; }

        public string? NotesFilter { get; set; }

    }
}