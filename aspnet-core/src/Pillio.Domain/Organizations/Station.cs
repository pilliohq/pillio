using System;
using System.ComponentModel.DataAnnotations.Schema;
using Volo.Abp.Domain.Entities;

namespace App.Organizations
{
    [Table("Stations")]
    public class Station : Entity<Guid>
    {
        public Station(Guid id) : base(id)
        {
        }

        public virtual string Name { get; set; }

        public virtual string? Notes { get; set; }
    }
}