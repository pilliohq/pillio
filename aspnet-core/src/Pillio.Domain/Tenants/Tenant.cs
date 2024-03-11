namespace Pillio.Domains;

public class Tenant
{
    public TenantType? Type { get; set; }

    public Guid? OrganizationId { get; set; }
}