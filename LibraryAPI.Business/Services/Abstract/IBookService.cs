
using LibraryAPI.Core.Entities.Dtos.Book;
using LibraryAPI.Core.Entities.FnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IBookService
    {
        IEnumerable<BookBrowseDto> GetBooksBrowse();
        BookDto GetBooksById(int id);
        IEnumerable<FN_GetBooksByFilter> GetBooksByFilter(string nameOrDescription);
        ResultInfo AddBook(BookDto book);
    }
}
