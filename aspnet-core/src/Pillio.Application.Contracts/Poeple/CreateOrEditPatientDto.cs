namespace Pillio.People
{
    public class CreateOrEditPatientDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

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

        public Guid? PharmacyId { get; set; }

        public Guid? DoctorOfficeId { get; set; }

        public Guid? InsuranceCardId { get; set; }

        public Guid? TimePlanId { get; set; }

        public Guid? StationId { get; set; }

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
