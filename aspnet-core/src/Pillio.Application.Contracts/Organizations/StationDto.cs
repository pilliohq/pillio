using System;
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations.Dtos
{
    public class StationDto : EntityDto<Guid>
    {
        public string? Name { get; set; }

        public int? CareHomeId { get; set; }

    }
}