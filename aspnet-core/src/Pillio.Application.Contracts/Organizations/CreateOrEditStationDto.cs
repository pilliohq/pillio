using System;
using Volo.Abp.Application.Dtos;

namespace App.Organizations.Dtos
{
    public class CreateOrEditStationDto : EntityDto<Guid?>
    {

        public string? Name { get; set; }

        public int? CareHomeId { get; set; }

    }
}