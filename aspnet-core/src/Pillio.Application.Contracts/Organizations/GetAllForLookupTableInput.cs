using Volo.Abp.Application.Dtos;

namespace App.Organizations.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}