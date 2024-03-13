namespace Pillio.Medications.Dtos
{
    public class MedicationPlanProductDto : EntityDto<Guid>
    {
        public float UsedCount { get; set; }

        public float Count { get; set; }

        public float AvailableCount => Count - UsedCount;

        public DateTime StartDate { get; set; }

        public MedicationPlanStatus Status { get; set; }

        public MedicationPlanFrequency Frequency { get; set; }

        public bool BillPack { get; set; }

        public bool ExactlySamePrescription { get; set; }

        public string Notes { get; set; }

        public List<string> WeeklyFrequencyDays { get; set; } = new List<string>();

        public DateTime CurrentBatchEndDate { get; set; }

        public PrescriptionStatus PrescriptionStatus { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public string ProductName { get; set; }

        public Guid? MedicationPlanId { get; set; }

        public Guid? ProductId { get; set; }

        public virtual float DosingSchedule1Value { get; set; }

        public virtual float DosingSchedule2Value { get; set; }

        public virtual float DosingSchedule3Value { get; set; }

        public virtual float DosingSchedule4Value { get; set; }

        public Guid? PatientId { get; set; }
        public string? PatientName { get; set; }
    }
}