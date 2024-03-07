
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Dtos
{
    public class GetAllStationsInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public string? CareHomeNameFilter { get; set; }

        public int? CareHomeIdFilter { get; set; }
    }
}