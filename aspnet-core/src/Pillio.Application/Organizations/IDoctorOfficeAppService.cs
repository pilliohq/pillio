using Pillio.Organizations.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations
{
    public interface IDoctorOfficeAppService : ICrudAppService< //Defines CRUD methods
            DoctorOfficeDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateOrEditDoctorOfficeDto> //Used to create/update a book
    {

    }
}
