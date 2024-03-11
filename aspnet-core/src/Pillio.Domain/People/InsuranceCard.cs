

namespace Pillio.People;

[Table("InsuranceCards")]
public class InsuranceCard : Entity<Guid>
{

    [Required]
    public virtual string CompanyName { get; set; }

    public virtual InsuranceType Type { get; set; }

    public virtual string? Number { get; set; }

    public virtual bool FreeOfCharge { get; set; }

}
