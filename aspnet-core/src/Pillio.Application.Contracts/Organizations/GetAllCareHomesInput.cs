namespace Pillio.Organizations.Dtos
{

    public class GetAllCareHomesInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public string? NameFilter { get; set; }

        public string? AddressFilter { get; set; }

        public string? FloorsFilter { get; set; }

        public string? NotesFilter { get; set; }

    }
}