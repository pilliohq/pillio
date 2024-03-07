
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Dtos
{
    public class GetAllDoctorOfficesInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public string? NameFilter { get; set; }

        public string? FirstNameFilter { get; set; }

        public string? LastNameFilter { get; set; }

        public string? EmailFilter { get; set; }

        public string? PhoneFilter { get; set; }

    }
}