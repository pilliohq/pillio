namespace Pillio.Medications
{
    [Table("Products")]
    public class Product : FullAuditedEntity<Guid>
    {

        [Required]
        public virtual string PZN { get; set; }

        [Required]
        public virtual string? Name { get; set; }

        public virtual bool PrescriptionRequired { get; set; }

        public virtual PackageType Type { get; set; }

        public virtual int PackageSize { get; set; }

        public virtual PackageForm Formulation { get; set; }

        public virtual string? Provider { get; set; }

        public virtual string? ActiveIngredients { get; set; }

        public virtual string? Excipients { get; set; }

        public virtual string? Other { get; set; }


        // public Medication Medication { get; set; }

    }
}