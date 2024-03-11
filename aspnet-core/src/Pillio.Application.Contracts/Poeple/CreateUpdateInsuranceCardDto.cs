
namespace Pillio.People
{
    public class CreateUpdateInsuranceCardDto
    {
        [Required]
        public string CompanyName { get; set; } = string.Empty;

        public InsuranceType Type { get; set; }

        public string? Number { get; set; }

        public bool FreeOfCharge { get; set; }
    }
}
