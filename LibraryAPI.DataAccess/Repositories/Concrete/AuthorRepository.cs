using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class AuthorRepository : EntityBaseRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<Author> GetAuthorByNameOrSurnaame(string name)
        {
            string nameLower = name.ToLower();
            return dbSet.Where(a => a.FirstName.ToLower().Contains(nameLower) || a.LastName.ToLower().Contains(nameLower));
        }
    }
}
