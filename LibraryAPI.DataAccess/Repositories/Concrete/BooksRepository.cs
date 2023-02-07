using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class BooksRepository : EntityBaseRepository<Books>, IBooksRepository
    {
        public BooksRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public Books GetByIdWithAuthor(int id)
        {
            return dbSet
                .Include(b=>b.Category)
                .Include(b => b.Author)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
