namespace Pillio.People;

[Table("Nurses")]
public class Nurse : Entity<long>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public virtual Guid? StationId { get; set; }

    [ForeignKey("StationId")]
    public virtual Station? Station { get; set; }

    public virtual TimeSpan? WorkingFromTime { get; set; }
    public virtual TimeSpan? WorkingToTime { get; set; }

    public bool IsLeadNurse { get; set; }
}
