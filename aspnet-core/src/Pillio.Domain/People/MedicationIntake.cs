using Pillio.Medications;

namespace Pillio.People;

public class MedicationIntake : CreationAuditedEntity<long>
{
   public DateTime Date { get; set; }
   public float Amount { get; set; }

   public virtual long OrderProductId { get; set; }

   [ForeignKey("MedicationPlanProductId")]
   public OrderProduct Product { get; set; }

}