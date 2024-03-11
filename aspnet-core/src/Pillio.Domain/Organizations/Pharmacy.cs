namespace Pillio.Organizations.Pharmacies
{
    [Table("Pharmacies")]
    public class Pharmacy : FullAuditedAggregateRoot<Guid>
    {
        protected Pharmacy()
        {
            
        }

        public Pharmacy(Guid id)
        {
            Id = id;
        }
        [Required]
        public virtual string Name { get; set; }

        public virtual string? Address { get; set; }

        public string? Email { get; set; }

        public virtual string? Notes { get; set; }

        public Guid? PharmacyTenantId { get; set; }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Phone { get; set; }

        public Guid? AvatarId { get; set; }
        [ForeignKey("AvatarId")]
        public virtual CloudFile Avatar { get; set; }

    }
}