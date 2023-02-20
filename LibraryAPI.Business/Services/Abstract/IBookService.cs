
using Core.Utilities.Results;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.Core.Entities.SpModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IBookService
    {
        Result GetBooksBrowse();
        Result GetBookById(int id);
        Result GetBooksByFilter(string nameOrDescription); 
        ResultInfo AddOrUpdateBook(BookAddOrUpdateDto book);
        ResultInfo DeleteBook(int id);
        Result GetBooksByCategoryFilter(int categoryId);

    }
}
