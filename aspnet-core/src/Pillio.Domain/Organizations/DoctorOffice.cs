using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Pillio.Common;

namespace Pillio.Organizations
{
    [Table("DoctorOffices")]
    public class DoctorOffice : FullAuditedAggregateRoot<Guid>
    {

        protected DoctorOffice()
        {

        }

        public DoctorOffice(Guid id)
        {
            Id = id;
        }
        [Required]
        public virtual string Name { get; set; }

        public virtual string? FirstName { get; set; }

        public virtual string? LastName { get; set; }

        public virtual string? Email { get; set; }

        public virtual string? Phone { get; set; }

        public Guid? DoctorTenantId { get; set; }

        public Guid? AvatarId { get; set; }
        [ForeignKey("AvatarId")]
        public virtual CloudFile Avatar { get; set; }


    }
}