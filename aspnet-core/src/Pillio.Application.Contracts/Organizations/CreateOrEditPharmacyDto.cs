using System.ComponentModel.DataAnnotations;
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Pharmacies.Dtos
{
    public class CreateOrEditPharmacyDto : EntityDto<int?>
    {

        [Required]
        public string Name { get; set; }

        public string? Address { get; set; }

        public string? Notes { get; set; }

        public int? PharmacyTenantId { get; set; }
        public int? AvatarId { get; set; }

    }
}