namespace Pillio.Medications
{
    [NotMapped]
    public class MedicationPlanWorkflowInfo
    {
        public long? ConfirmationTenantId { get; set; }

        public string? ConfirmationTenantName { get; set; }

        public string? ConfirmationUserName { get; set; }
        public DateTime? ConfirmationDate { get; set; }

        public long? ApprovalTenantId { get; set; }
        public string? ApprovalUserName { get; set; }
        public DateTime? ApprovalDate { get; set; }


        public long? DeliveryTenantId { get; set; }
        public string? DeliveryTenantName { get; set; }
        public string? DeliveryUserName { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public bool? IsCompleted { get; set; }

        public string Notes { get; set; }

        public WorkflowMoreInfo MoreInfo { get; set; } = new WorkflowMoreInfo();
    }

    public class WorkflowMoreInfo
    {

    }
}
