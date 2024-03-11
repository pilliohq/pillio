namespace Pillio.People
{
    public class PatientDto : AuditedEntityDto<Guid>
    {
        public Guid? TenantId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public DateTime? DoB { get; set; }

        public Gender Gender { get; set; }

        public int HeightInCm { get; set; }

        public int WeightInKg { get; set; }

        public float WeightInKgIncrease { get; set; }

        public string? StreetAndHouseNumber { get; set; }

        public string? AdditionalInformation { get; set; }

        public bool UseAsDeliveryAddress { get; set; }

        public string? City { get; set; }

        public string? PostalCode { get; set; }

        public string? Country { get; set; }

        public Guid? CareHomeId { get; set; }

        public CareHomeDto? CareHome { get; set; }

        public Guid? PharmacyId { get; set; }

        public PharmacyDto? Pharmacy { get; set; }

        public Guid? DoctorOfficeId { get; set; }

        public DoctorOfficeDto? DoctorOffice { get; set; }

        public Guid? InsuranceCardId { get; set; }

        public InsuranceCardDto? InsuranceCard { get; set; }

        public Guid? TimePlanId { get; set; }

        public TimePlanDto? TimePlan { get; set; }

        public Guid? StationId { get; set; }

        public StationDto? Station { get; set; }

        public string FullName => FirstName + " " + LastName;

        public Guid? AvatarId { get; set; }


        public Guid? LeadNurseId { get; set; }


        public string? FamilyRelationship { get; set; }

        public string? FamilyFirstName { get; set; }

        public string? FamilyLastName { get; set; }

        public string? FamilyPhone { get; set; }

        public string? FamilyEmail { get; set; }

        // public ICollection<MedicationOrderDto> Orders { get; set; }

        public PatientMetaDataDto MetaData { get; set; } = new PatientMetaDataDto();
    }
}
