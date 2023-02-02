using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.DataAccess.Infrastructure.Tools.EfCore;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class BookService : IBooksService
    {
        private readonly IBooksRepository _booksRepository;

        public BookService(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public IEnumerable<FN_GetBooksBrowse> GetBooksBrowse()
        {
            string pageCount = "200";
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam("pageCount", pageCount);

            var data = DbTools.ExecuteFuncion<FN_GetBooksBrowse>("dbo.FN_GetBooksBrowse", parameters);
            return data;
        }
    }
}
