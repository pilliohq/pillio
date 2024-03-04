using Pillio.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using AutoMapper.Configuration.Annotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Pillio.People
{
    [Table("Patients")]
    public class Patient : FullAuditedEntity<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        [Required]
        public virtual string FirstName { get; set; }

        [Required]
        public virtual string LastName { get; set; }

        public virtual string Email { get; set; }

        public virtual string Phone { get; set; }

        public virtual DateTime? DoB { get; set; }

        public virtual Gender Gender { get; set; }

        public virtual int HeightInCm { get; set; }

        public virtual int WeightInKg { get; set; }
        public virtual float WeightInKgIncrease { get; set; }

        public virtual string StreetAndHouseNumber { get; set; }

        public virtual string AdditionalInformation { get; set; }

        public virtual bool UseAsDeliveryAddress { get; set; }

        public virtual string City { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual int? CareHomeId { get; set; }

        [ForeignKey("CareHomeId")]
        public CareHome CareHomeFk { get; set; }

        public virtual int? PharmacyId { get; set; }

        [ForeignKey("PharmacyId")]
        public Pharmacy PharmacyFk { get; set; }

        public virtual int? DoctorOfficeId { get; set; }

        [ForeignKey("DoctorOfficeId")]
        public DoctorOffice DoctorOfficeFk { get; set; }

        public virtual int? InsuranceCardId { get; set; }

        [Ignore]
        [ForeignKey("InsuranceCardId")]
        public InsuranceCard InsuranceCardFk { get; set; }

        public virtual int? TimePlanId { get; set; }

        [ForeignKey("TimePlanId")]
        public TimePlan TimePlanFk { get; set; }

        public int? StationId { get; set; }
        [ForeignKey("StationId")]
        public virtual Station StationFk { get; set; }

        public string FullName => FirstName + " " + LastName;

        public long? GroupChatId { get; set; }

        [ForeignKey("GroupChatId")]
        public GroupChat GroupChatFk { get; set; }

        public int? AvatarId { get; set; }
        [ForeignKey("AvatarId")]
        public virtual CloudFile AvatarFk { get; set; }


        public long? PrimaryNurseId { get; set; }
        [ForeignKey("PrimaryNurseId")]
        public virtual User PrimaryNurse { get; set; }

        public string FamilyRelationship { get; set; }

        public string FamilyFirstName { get; set; }
        public string FamilyLastName { get; set; }

        public string FamilyPhone { get; set; }
        public string FamilyEmail { get; set; }

        public virtual ICollection<MedicationOrder> Orders { get; set; }

        public PatientMetaData MetaData { get; set; } = new PatientMetaData();
    }

    [NotMapped]
    public class PatientMetaData
    {
        public List<string> HealthStatuses { get; set; } = new List<string>();

        public string BloodPressure { get; set; }

        public virtual float BloodPressureIncrease { get; set; }

        public virtual float BloodSugarInCrease { get; set; }

        public string BloodSugar { get; set; }

        public List<string> Symptoms { get; set; } = new List<string>();

        public List<string> CommonSymptomsAndSideEffects = new List<string>();
    }
}