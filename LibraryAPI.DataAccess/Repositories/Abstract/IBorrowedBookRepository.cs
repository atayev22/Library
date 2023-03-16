using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Abstract
{
    public interface IBorrowedBookRepository : IEntityBaseRepository<BorrowedBook>
    {
        IQueryable<BorrowedBook> GetBorrowedBooksBrowse();
        IQueryable<BorrowedBook> GetBorrowedBooksByBookId(int bookId);
        IQueryable<BorrowedBook> GetBorrowedBooksByReaderId(int readerId);
        IQueryable<BorrowedBook> GetBorrowedBooksByDateInterval(DateTime firstDate, DateTime secondDate);
    }
}
