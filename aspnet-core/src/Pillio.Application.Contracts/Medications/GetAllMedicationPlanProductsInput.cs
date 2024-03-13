

namespace Pillio.Medications.Dtos
{
    public class GetAllMedicationPlanProductsInput : PagedAndSortedResultRequestDto
    {
        public bool? IsFilling { get; set; }
        public bool? IsWaitingPrescription { get; set; }
        public bool? IsWaitingConfirmation { get; set; }
        public bool? IsWaitingForDelivery { get; set; }
        public bool? IsDelivery { get; set; }
    }
}