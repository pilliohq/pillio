using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}