using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities.Auditing;
using Pillio.Common;
using System.Collections;
using System.Collections.Generic;

namespace App.Organizations
{
    [Table("CareHomes")]
    public class CareHome : FullAuditedAggregateRoot<Guid>
    {
        protected CareHome() { }

        public CareHome(Guid id)
        {
            Id = id;
        }

        [Required]
        public virtual string Name { get; set; }

        public virtual string? Address { get; set; }

        public virtual string? Floors { get; set; }

        public virtual string? Notes { get; set; }

        public string? PostalCode { get; set; }

        public string? City { get; set; }

        public DayOfWeek DeliveryDay { get; set; } = DayOfWeek.Monday;

        public TimeSpan DeliveryTime { get; set; } = new TimeSpan(8, 0, 0);

        public Guid? CareHomeTenantId { get; set; }

        public Guid? AvatarId { get; set; }
        [ForeignKey("AvatarId")]
        public virtual CloudFile Avatar { get; set; }

        public virtual List<Station> Stations { get; set; }

    }
}