using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;
using Volo.Abp.MultiTenancy;

namespace App.People
{
    [Table("Nurses")]
    public class Nurse : Entity<long>, IMultiTenant
    {
        public Guid? TenantId { get; set; }

        public virtual int StationId { get; set; }

        [ForeignKey("StationId")]
        public virtual Station Station { get; set; }

        public virtual TimeSpan? WorkingFromTime { get; set; }
        public virtual TimeSpan? WorkingToTime { get; set; }
    }
}