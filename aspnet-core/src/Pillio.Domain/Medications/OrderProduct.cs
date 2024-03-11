namespace Pillio.Medications;

[Table("OrderProducts")]

public class OrderProduct : FullAuditedEntity<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }
    public Guid MedicationPlanProductId { get; set; }

    [ForeignKey("MedicationPlanProductId")]
    public MedicationPlanProduct MedicationPlanProduct { get; set; }
    
    public virtual float UsedCount { get; set; }

    public virtual float Count { get; set; }

    public float AvailableCount => Count - UsedCount;

    public MedicationAvailableStatus AvailableStatus => AvailableCount <= 7 ? MedicationAvailableStatus.Red : AvailableCount <= 14 ? MedicationAvailableStatus.Yellow : MedicationAvailableStatus.Green;

    public MedicationPlanWorkflowInfo Workflow = new MedicationPlanWorkflowInfo();

    public DateTime? StatusLastChanged { get; set; }

    public Guid? WorkflowPersonInChargeId { get; set; }
    public Volo.Abp.TenantManagement.Tenant WorkflowPersonInCharge { get; set; }//doctor or pharmacy
    public virtual DateTime StartDate { get; set; }

    public virtual DateTime? CurrentBatchEndDate { get; set; }


    public virtual PrescriptionStatus PrescriptionStatus { get; set; }

    public virtual OrderProductActionType ActionType { get; set; } = OrderProductActionType.None;

    public long? MedicationOrderId { get; set; }

    [ForeignKey("PatientId")]
    public MedicationOrder MedicationOrder { get; set; }

    public DateTime CalculateEndDate()
    {
        var takenPerDay = MedicationPlanProduct.DosingSchedule1Value;
        if (MedicationPlanProduct.DosingSchedule2Value > 0) takenPerDay += MedicationPlanProduct.DosingSchedule2Value;
        if (MedicationPlanProduct.DosingSchedule3Value > 0) takenPerDay += MedicationPlanProduct.DosingSchedule3Value;
        if (MedicationPlanProduct.Frequency == MedicationPlanFrequency.Daily)
        {
            return StartDate.AddDays(Math.Floor((double)Count / takenPerDay));
        }
        else if (MedicationPlanProduct.Frequency == MedicationPlanFrequency.Weekly)
        {
            var takenPerWeek = takenPerDay * MedicationPlanProduct.WeeklyFrequencyDays.Count;
            var inDays = (decimal)(Count / takenPerWeek) * 7;
            return StartDate.AddDays((int)inDays);
        }
        //TODO: calculate for other frequency
        return StartDate.AddDays(Count);
    }

}