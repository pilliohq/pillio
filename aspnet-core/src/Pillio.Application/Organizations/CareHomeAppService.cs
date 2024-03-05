using App.Organizations;
using App.Organizations.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Pillio.Organizations
{
    public class CareHomeAppService : CrudAppService<
            CareHome, //The Book entity
            CareHomeDto, //Used to show books
            Guid, //Primary key of the book entity
            PagedAndSortedResultRequestDto, //Used for paging/sorting
            CreateOrEditCareHomeDto>, //Used to create/update a book
            ICareHomeAppService
    {
        public CareHomeAppService(IRepository<CareHome, Guid> repository) : base(repository)
        {
        }
    }
}
