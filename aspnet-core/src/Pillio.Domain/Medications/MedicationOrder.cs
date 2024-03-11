
namespace Pillio.Medications;

[Table("MedicationOrders")]
public class MedicationOrder : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public virtual Guid? MedicationPlanId { get; set; }

    [ForeignKey("MedicationPlanId")]
    public MedicationPlan? MedicationPlan { get; set; }

    public virtual Guid? NurseId { get; set; }

    [ForeignKey("NurseId")]
    public Nurse? Nurse { get; set; }

    public OrderStatus Status { get; set; }
    public MedicationPlanWorkflowInfo Workflow { get; set; }
    public virtual ICollection<OrderProduct> Products { get; set; }
    public DateTime? DeliveryDate { get; set; }

    public ICollection<CloudFile> Files { get; set; } = new List<CloudFile>();

    public virtual Guid? CareHomeId { get; set; }

    [ForeignKey("PatientId")]
    public virtual Patient? Patient { get; set; }

    public virtual Guid? PatientId { get; set; }

    public bool IsCurrentOrder { get; set; }

}
