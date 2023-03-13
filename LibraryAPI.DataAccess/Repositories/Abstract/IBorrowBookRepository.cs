using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Repositories.Abstract
{
    public interface IBorrowBookRepository : IEntityBaseRepository<BorrowedBook>
    {
        IQueryable<BorrowedBook> GetBorrowBooksBrowse();
        IQueryable<BorrowedBook> GetBorrowBooksByBookId(int bookId);
        IQueryable<BorrowedBook> GetBorrowBooksByReaderId(int readerId);
        IQueryable<BorrowedBook> GetBorrowBooksByDateInterval(DateTime firstDate, DateTime secondDate);
    }
}
