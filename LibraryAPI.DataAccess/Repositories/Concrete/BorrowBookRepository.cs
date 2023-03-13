using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class BorrowBookRepository : EntityBaseRepository<BorrowedBook>, IBorrowBookRepository
    {
        public BorrowBookRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<Book> GetBorrowBooksBrowse()
        {
            throw new NotImplementedException();
        }
    }
}
