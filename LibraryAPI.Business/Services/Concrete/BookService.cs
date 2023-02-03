using AutoMapper;
using LibraryApi.BaseLog.Entities.Dtos;
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
        private readonly IMapper _mapper;

        public BookService(IBooksRepository booksRepository,IMapper mapper)
        {
            _mapper = mapper;
            _booksRepository = booksRepository;
        }
    
        public IEnumerable<BooksDto> GetBooksBrowse()
        {
            var data = _mapper.Map<IEnumerable<BooksDto>>(_booksRepository.GetAll());

            return data;
        }

        public IEnumerable<FN_GetBooksBrowse> GetBooksByFilter(string nameOrDescription)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam("nameOrDescription", nameOrDescription);

            var data = DbTools.ExecuteFunction<FN_GetBooksBrowse>("dbo.FN_GetBooksByFilter", parameters);
            return data;
        }
    }
}
