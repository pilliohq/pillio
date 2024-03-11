namespace Pillio.Organizations.Dtos
{
    public class DoctorOfficeDto : AuditedEntityDto<Guid>
    {
        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public int? DoctorTenantId { get; set; }

    }
}