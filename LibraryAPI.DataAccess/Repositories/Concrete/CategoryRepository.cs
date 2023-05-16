using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Utilities.Tools.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class CategoryRepository : EntityBaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<Category> GetCategoriesBrowse(PageHandler paginator,out int pageCount)
        {
            pageCount = (int)Math.Ceiling(dbSet.Count() / (decimal)paginator.VisibleItemCount);
            var response = dbSet
                .OrderByDescending(c => c.Id)
                .Skip((paginator.Page - 1) * paginator.VisibleItemCount)
                .Take(paginator.VisibleItemCount);

            return response;
        }
    }
}
