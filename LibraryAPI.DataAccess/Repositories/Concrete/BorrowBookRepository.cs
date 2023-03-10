using AutoMapper;
using LibraryAPI.DataAccess.Context;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Concrete
{
    public class BorrowBookRepository : EntityBaseRepository<BorrowedBook>, IBorrowBookRepository
    {
        public BorrowBookRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<BorrowedBook> GetBorrowBooksBrowse()
        {
            return dbSet.Include(b => b.Book)
                        .Include(r => r.Reader)
                        .OrderBy(ld => ld.LendDate);
        }

        public IQueryable<BorrowedBook> GetBorrowBooksByBookId(int bookId)
        {
            return dbSet.Where(b => b.BookId == bookId);
        }

        public IQueryable<BorrowedBook> GetBorrowBooksByDateInterval(DateTime firstDate, DateTime secondDate)
        {
            return dbSet.Where(ld => firstDate <= ld.LendDate && ld.LendDate <= secondDate);
        }

        public IQueryable<BorrowedBook> GetBorrowBooksByReaderId(int readerId)
        {
            return dbSet.Where(b => b.ReaderId == readerId);
        }
    }
}
