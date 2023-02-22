using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.Core.Entities.SpModels;
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
        private readonly IBookRepository _booksRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository booksRepository,IMapper mapper)
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

        public ResultInfo DeleteBook(int id)
        {
            var response = _booksRepository.Delete(id);
            if(response is false)
            {
                return ResultInfo.NotFound;
            }
            return ResultInfo.Deleted;
        }

        public Result GetBooksBrowse()
        {
            var result = new Result();

            var response = _mapper.Map<IEnumerable<BookBrowseDto>>(_booksRepository.GetBooksBrowse().ToList());
            result.Data = response;

            return result;
        }

        public Result GetBooksByCategoryFilter(int categoryId)
        {
            var result = new Result();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam(nameof(categoryId), categoryId);

            var response = DbTools.ExecuteProcedure<SP_GetBooksByCategoryFilter>("SP_GetBooksByCategoryFilter", parameters);
            result.Data = response;
            
            return result;
        }

        public Result GetBooksByFilter(string nameOrDescription) //IEnumerable<FN_GetBooksByFilter>
        {
            var result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam(nameof(nameOrDescription), nameOrDescription);

            var response = DbTools.ExecuteFunction<FN_GetBooksByFilter>("dbo.FN_GetBooksByNameFilter", parameters);
            if(response is null)
            {
                response = DbTools.ExecuteFunction<FN_GetBooksByFilter>("dbo.FN_GetBooksByDescriptionFilter", parameters);
                result.Data = response;
                return result;
            }
            result.Data = response;
            return result;
        }

        public Result GetBookById(int id)
        {
            var result = new Result();  

            var book = _booksRepository.GetByIdWithAllRelations(id);
            var data = _mapper.Map<BookDto>(book);

            result.Data = data;

            if (result.Data is null)
            {
                return result;
            }         

            return result;
        }
    }
}
