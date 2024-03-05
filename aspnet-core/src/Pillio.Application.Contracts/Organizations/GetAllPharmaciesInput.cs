﻿
using Volo.Abp.Application.Dtos;

namespace App.Pharmacies.Dtos
{
    public class GetAllPharmaciesInput : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }

        public string? NameFilter { get; set; }

        public string? AddressFilter { get; set; }

        public string? NotesFilter { get; set; }

    }
}