using Pillio.Organizations.Dtos;
using System;
using Volo.Abp.Application.Dtos;

namespace Pillio.Organizations
{
    public interface ICareHomeAppService : ICrudAppService< //Defines CRUD methods
            CareHomeDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateOrEditCareHomeDto> //Used to create/update a book
    {

    }
}
