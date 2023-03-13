using Core.Utilities.Results;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IBorrowBookService
    {
        Result GetBorrowBooksBrowse();
        Result GetBorrowBookByReaderId(int readreId);
        Result GetBorrowBookByBookId(int bookId);
        Result GetBorrowBooksByDateInterval(DateTime date1, DateTime date2);
        ResultInfo AddOrUpdateBorrowBook(Reader reader);
        ResultInfo DeleteBorrowBook(int id);
    }
}
