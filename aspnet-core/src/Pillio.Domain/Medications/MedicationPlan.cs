
using Volo.Abp.TenantManagement;

namespace Pillio.Medications
{
    [Table("MedicationPlans")]
    public class MedicationPlan : FullAuditedAggregateRoot<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public virtual Guid? PatientId { get; set; }

        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public Guid? CareHomeTenantId { get; set; }
        public Guid? FamilyDoctorTenantId { get; set; }
        public Guid? PharmacyTenantId { get; set; }


        [ForeignKey("CareHomeTenantId")]
        public Tenant? CareHomeTenant { get; set; }

        [ForeignKey("FamilyDoctorTenantId")]
        public Tenant? FamilyDoctorTenant { get; set; }

        [ForeignKey("PharmacyTenantId")]
        public Tenant? PharmacyTenant { get; set; }

        public virtual ICollection<MedicationPlanProduct> Products { get; set; }

        public Guid? CurrentOrderId { get; set; }

        [ForeignKey("CurrentOrderId")]
        public MedicationOrder CurrentOrder { get; set; }


    }
}