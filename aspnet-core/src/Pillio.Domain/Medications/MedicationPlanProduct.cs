namespace Pillio.Medications
{
    [Table("MedicationPlanProducts")]
    public class MedicationPlanProduct : FullAuditedEntity<Guid>, IMultiTenant
    {
        public MedicationPlanProduct()
        {

        }

        public Guid? TenantId { get; set; }


        public virtual MedicationPlanFrequency Frequency { get; set; }

        public virtual bool BillPack { get; set; }

        public virtual bool ExactlySamePrescription { get; set; }

        public virtual string Notes { get; set; }

        public virtual List<string> WeeklyFrequencyDays { get; set; } = new List<string>();

        public virtual string ProductName => Product?.Name;

        public virtual Guid? MedicationPlanId { get; set; }

        [ForeignKey("MedicationPlanId")]
        public MedicationPlan MedicationPlan{ get; set; }

        public virtual Guid? CurrentOrderId { get; set; }

        [ForeignKey("CurrentOrderId")]
        public MedicationOrder CurrentOrder { get; set; }

        public virtual Guid? ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product{ get; set; }

        public virtual float DosingSchedule1Value { get; set; } = 0;

        public virtual float DosingSchedule2Value { get; set; } = 0;

        public virtual float DosingSchedule3Value { get; set; } = 0;

        public virtual float DosingSchedule4Value { get; set; } = 0;

        public virtual bool IsInCurrentWorkflow { get; set; }
       
    }
}
