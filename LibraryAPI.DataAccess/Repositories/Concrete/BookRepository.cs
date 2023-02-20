using AutoMapper;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
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
    public class BookRepository : EntityBaseRepository<Book>, IBookRepository
    {
        public BookRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<Book> GetBooksBrowse()
        {
            return dbSet.Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.PublishingHouse).OrderBy(p => p.Name);
        }

        public Book GetByIdWithAllRelations(int id)
        {
            return dbSet
                .Include(c => c.Category)
                .Include(a => a.Author)
                .Include(p => p.PublishingHouse)
                .FirstOrDefault(b => b.Id == id);
        }
    }
}
