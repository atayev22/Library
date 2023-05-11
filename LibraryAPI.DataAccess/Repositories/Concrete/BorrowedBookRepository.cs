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
    public class BorrowedBookRepository : EntityBaseRepository<BorrowedBook>, IBorrowedBookRepository
    {
        public BorrowedBookRepository(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public IQueryable<BorrowedBook> GetBorrowedBooksBrowse()
        {
            return dbSet.Include(b => b.Book)
                        .Include(r => r.Reader)
                        .OrderBy(ld => ld.LendDate);
        }

        public IQueryable<BorrowedBook> GetBorrowedBooksByBookId(int bookId)
        {
            return dbSet.Where(b => b.BookId == bookId);
        }

        public IQueryable<BorrowedBook> GetBorrowedBooksByDateInterval(DateTime firstDate, DateTime secondDate)
        {
            return dbSet.Where(ld => firstDate <= ld.LendDate && ld.LendDate <= secondDate)
                        .Include(b => b.Book)
                        .Include(r => r.Reader)
                        .Include(b => b.Book.Author)
                        .Include(b => b.Book.Category)
                        .Include(b => b.Book.PublishingHouse);
        }

        public IQueryable<BorrowedBook> GetBorrowedBooksByReaderId(int readerId)
        {
            return dbSet.Where(b => b.ReaderId == readerId)
                        .Include(b=> b.Book);
        }
    }
}
