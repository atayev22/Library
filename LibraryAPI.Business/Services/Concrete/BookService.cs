using AutoMapper;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.Book;
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Tools.EfCore;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class BookService : IBookService
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookService(IBooksRepository booksRepository,IMapper mapper)
        {
            _mapper = mapper;
            _booksRepository = booksRepository;
        }

        public ResultInfo AddOrUpdateBook(BookAddOrUpdateDto book)
        {
            var data = _mapper.Map<Book>(book);
            if (data.Id is 0)
            {
                _booksRepository.Add(data);
            }        
            else
            {
                _booksRepository.Update(data);
            }

            if(data is null)
            {
                return ResultInfo.NotImplemented;
            }

            return ResultInfo.Success;
        }

        public IEnumerable<BookBrowseDto> GetBooksBrowse()
        {
            var data = _mapper.Map<IEnumerable<BookBrowseDto>>(_booksRepository.GetBooksBrowse());

            return data;
        }

        public IEnumerable<FN_GetBooksByFilter> GetBooksByFilter(string nameOrDescription)
        {

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam(nameof(nameOrDescription), nameOrDescription);

            var data = DbTools.ExecuteFunction<FN_GetBooksByFilter>("dbo.FN_GetBooksByNameFilter", parameters);
            if(data is null)
            {
                data = DbTools.ExecuteFunction<FN_GetBooksByFilter>("dbo.FN_GetBooksByDescriptionFilter", parameters);
                return data;
            }    
            return data;
        }

        public BookDto GetBooksById(int id)
        {
            var book = _booksRepository.GetByIdWithAllRelations(id);

            if (book == null)
            {
                return null;
            }

            var data = _mapper.Map<BookDto>(book);

            return data;
        }
    }
}
