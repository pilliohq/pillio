

namespace Pillio.People
{
    public class InsuranceCardDto : EntityDto<Guid>
    {
        [Required]
        public string CompanyName { get; set; }

        public InsuranceType Type { get; set; }

        public string? Number { get; set; }

        public bool FreeOfCharge { get; set; }
    }
}
