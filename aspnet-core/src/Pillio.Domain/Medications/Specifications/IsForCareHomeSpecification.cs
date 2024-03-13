using System.Linq.Expressions;
using Pillio.Medications;
using Volo.Abp.Specifications;

namespace Pillio.Domains.Medications.Specifications;

public class MonthsAgoSpecification : Specification<OrderProduct>
{
    protected CareHome CareHome { get; set; }
    public Guid UserId { get; set; }

    public Guid TenantId { get; set; }

    public MonthsAgoSpecification(CareHome careHome, Guid userId, Guid tenantId)
    {
        CareHome = careHome;
        UserId = userId;
        TenantId = tenantId;
    }

    public override Expression<Func<OrderProduct, bool>> ToExpression()
    {
        return CareHome != null ? x => x.MedicationOrder.NurseId == UserId :
        x => x.MedicationOrder.MedicationPlan.PharmacyTenantId == TenantId;
    }
}