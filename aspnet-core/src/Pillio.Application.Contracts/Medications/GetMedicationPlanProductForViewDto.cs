

namespace Pillio.Medications.Dtos
{
    public class GetMedicationPlanProductForViewDto
    {
        public MedicationPlanProductDto MedicationPlanProduct { get; set; }

        public string MedicationPlanPatientName { get; set; }

        public string ProductName { get; set; }

        public string? ResponsiblePerson { get; set; }

        public OrderStatus OrderStatus { get; set; } = OrderStatus.None;
        public string PatientAvatarUrl { get; set; }
        public DateTime? DeliveryDate { get; set; }
        
        public MedicationPlanWorkflowInfo? OrderWorkflow { get; set; }
    }

}