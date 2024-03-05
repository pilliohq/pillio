using App.Organizations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

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
