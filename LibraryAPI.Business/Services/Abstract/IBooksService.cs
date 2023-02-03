using LibraryApi.BaseLog.Entities.Dtos;
using LibraryAPI.Core.Entities.FnModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IBooksService
    {
        IEnumerable<BooksDto> GetBooksBrowse();
        IEnumerable<FN_GetBooksByFilter> GetBooksByFilter(string nameOrDescription);
    }
}
