
using Volo.Abp.TenantManagement;

namespace Pillio.Medications
{
    [Table("MedicationPlans")]
    public class MedicationPlan : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public virtual Guid? PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public Guid? CareHomeTenantId { get; set; }
        public Guid? DoctorTenantId { get; set; }
        public Guid? PharmacyTenantId { get; set; }


        [ForeignKey("CareHomeTenantId")]
        public Tenant? CareHomeTenant { get; set; }

        [ForeignKey("DoctorTenantId")]
        public Tenant? DoctorTenant { get; set; }

        [ForeignKey("PharmacyTenantId")]
        public Tenant? PharmacyTenant { get; set; }

        public virtual ICollection<MedicationPlanProduct> Products { get; set; }

        public Guid? CurrentOrderId { get; set; }

        [ForeignKey("CurrentOrderId")]
        public MedicationOrder CurrentOrder { get; set; }


    }
}