namespace Pillio.Organizations.Dtos
{
    public class GetAllForLookupTableInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}