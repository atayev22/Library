using Core.Utilities.Results;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IBorrowedBookService
    {
        Result GetBorrowedBooksBrowse();
        Result GetBorrowedBooksByReaderId(int readreId);
        Result GetBorrowedBooksByBookId(int bookId);
        Result GetBorrowedBooksByDateInterval(DateTime firstDate, DateTime secondDate);
        ResultInfo AddOrUpdateBorrowedBook(BorrowedBookDto reader);
        ResultInfo DeleteBorrowedBook(int id);
        ResultInfo SendMailToReader(int readerId);
    }
}
