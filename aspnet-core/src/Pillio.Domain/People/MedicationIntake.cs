using Pillio.Medications;

namespace Pillio.People;

public class MedicationIntake : CreationAuditedEntity<Guid>
{
   public DateTime Date { get; set; }
   public float Amount { get; set; }

   public virtual Guid OrderProductId { get; set; }

   [ForeignKey("MedicationPlanProductId")]
   public OrderProduct Product { get; set; }

}