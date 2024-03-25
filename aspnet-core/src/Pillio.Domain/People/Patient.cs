using Pillio.Medications;

namespace Pillio.People;

[Table("Patients")]
public class Patient : FullAuditedAggregateRoot<Guid>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    [Required]
    public virtual string FirstName { get; set; }

    [Required]
    public virtual string LastName { get; set; }

    public virtual string? Email { get; set; }

    public virtual string? Phone { get; set; }

    public virtual DateTime? DoB { get; set; }

    public virtual Gender Gender { get; set; }

    public virtual int HeightInCm { get; set; }

    public virtual int WeightInKg { get; set; }
    public virtual float WeightInKgIncrease { get; set; }

    public virtual string? StreetAndHouseNumber { get; set; }

    public virtual string? AdditionalInformation { get; set; }

    public virtual bool UseAsDeliveryAddress { get; set; }

    public virtual string? City { get; set; }

    public virtual string? PostalCode { get; set; }

    public virtual string? Country { get; set; }

    public virtual Guid? CareHomeId { get; set; }

    [ForeignKey("CareHomeId")]
    public CareHome? CareHome { get; set; }

    public virtual Guid? PharmacyId { get; set; }

    [ForeignKey("PharmacyId")]
    public Pharmacy? Pharmacy { get; set; }

    public virtual Guid? DoctorOfficeId { get; set; }

    [ForeignKey("DoctorOfficeId")]
    public DoctorOffice? DoctorOffice { get; set; }

    public virtual Guid? InsuranceCardId { get; set; }

    [Ignore]
    [ForeignKey("InsuranceCardId")]
    public InsuranceCard? InsuranceCard { get; set; }

    public virtual Guid? TimePlanId { get; set; }

    [ForeignKey("TimePlanId")]
    public TimePlan? TimePlan { get; set; }

    public Guid? StationId { get; set; }
    [ForeignKey("StationId")]
    public virtual Station? Station { get; set; }

    public string FullName => FirstName + " " + LastName;

    // public long? GroupChatId { get; set; }

    // [ForeignKey("GroupChatId")]
    // public GroupChat GroupChat{ get; set; }

    public Guid? AvatarId { get; set; }
    [ForeignKey("AvatarId")]
    public virtual CloudFile? Avatar { get; set; }


    public Guid? LeadNurseId { get; set; }
    [ForeignKey("LeadNurseId")]
    public virtual Nurse? LeadNurse { get; set; }

    public string? FamilyRelationship { get; set; }

    public string? FamilyFirstName { get; set; }
    public string? FamilyLastName { get; set; }

    public string? FamilyPhone { get; set; }
    public string? FamilyEmail { get; set; }

    public virtual ICollection<MedicationOrder> Orders { get; set; } = [];

    public virtual ICollection<MedicationPlan> MedicationPlans { get; set; } = [];

    public PatientMetaData MetaData { get; set; } = new PatientMetaData();
}

[NotMapped]
public class PatientMetaData
{
    public List<string> HealthStatuses { get; set; } = [];

    public string? BloodPressure { get; set; }

    public virtual float BloodPressureIncrease { get; set; }

    public virtual float BloodSugarInCrease { get; set; }

    public string? BloodSugar { get; set; }

    public List<string> Symptoms { get; set; } = [];

    public List<string> CommonSymptomsAndSideEffects = [];
}
