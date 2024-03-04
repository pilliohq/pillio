using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace Pillio.People;

[Table("PatientVisit")]
public class PatientVisit : FullAuditedEntity<long>, IMultiTenant
{
    public Guid? TenantId { get; set; }

    public long MedicationOrderId { get; set; }
    [ForeignKey("MedicationOrderId")]
    public MedicationOrder MedicationOrder { get; set; }

    public long NurseId { get; set; }
    [ForeignKey("NurseId")]
    public virtual User Nurse { get; set; }

    public virtual int PatientId { get; set; }

    [ForeignKey("PatientId")]
    public Patient Patient { get; set; }

    public bool DosingSchedule1 { get; set; }

    public bool DosingSchedule2 { get; set; }

    public bool DosingSchedule3 { get; set; }


    public List<MedicationIntake> MedicationIntakes { get; set; } = new List<MedicationIntake>();

    public virtual List<CloudFile> AudioNotes { get; set; } = new List<CloudFile>();

    public string NotesSummary { get; set; }

    public string Notes { get; set; }

    public PatientVisitMetaData MetaData { get; set; } = new PatientVisitMetaData();

}



[NotMapped]
public class PatientVisitMetaData
{
    public float? Temperature { get; set; }

    public string Symtoms { get; set; }
    public string Abnormal { get; set; }
}
