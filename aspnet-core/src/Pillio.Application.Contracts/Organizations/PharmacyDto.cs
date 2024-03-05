using System;
using Volo.Abp.Application.Dtos;

namespace App.Pharmacies.Dtos
{
    public class PharmacyDto : AuditedEntityDto<Guid>
    {
        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? Notes { get; set; }

        public int? PharmacyTenantId { get; set; }


    }
}