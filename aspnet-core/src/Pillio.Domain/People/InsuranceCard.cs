using Pillio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace Pillio.People
{
    [Table("InsuranceCards")]
    public class InsuranceCard : Entity<int>
    {

        [Required]
        public virtual string CompanyName { get; set; }

        public virtual InsuranceType Type { get; set; }

        public virtual string Number { get; set; }

        public virtual bool FreeOfCharge { get; set; }

    }
}