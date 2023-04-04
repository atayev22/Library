using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using LibraryAPI.DataAccess.Utilities.Tools.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Abstract
{
    public interface ICategoryRepository : IEntityBaseRepository<Category>
    {
        IQueryable<Category> GetCategoriesBrowse(PageHandler paginator, out int pageCount);
    }
}
