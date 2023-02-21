using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.AuthorDtos;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.FnModels;
using LibraryAPI.Core.Entities.SpModels;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Infrastructure.Repositories.Concrete;
using LibraryAPI.DataAccess.Infrastructure.Tools.EfCore;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        public Result GetAuthorsBrose()
        {
            var result = new Result();

            var data = _mapper.Map<IEnumerable<AuthorBrowseDto>>(_authorRepository.GetAll().ToList());
            result.Data = data;

            return result;
        }

        public Result GetAuthorById(int id)
        {
            var result = new Result();

            var author = _authorRepository.Get(id);
            result.Data = author;
            if (result.Data == null)
            {
                return result;
            }
            return result;
        }

        public Result GetAuthorByName(string name)
        {
            var result = new Result();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.AddParam(nameof(name), name);

            var data = DbTools.ExecuteProcedure<SP_GetAuthorByName>("dbo.SP_GetAuthorByName", parameters);
            result.Data = data;

            return result;
        }

        public ResultInfo AddOrUpdateAuthor(Author author)
        {
            var result = new Result();
            if(author.Id is 0)
            {
               _authorRepository.Add(author);
            }
            else
            {
                _authorRepository.Update(author);
            }

            if (author is null)
            {
                return ResultInfo.NotImplemented;
            }

            return ResultInfo.Success;  

        }

        public ResultInfo DeleteAuthor(int id)
        {
            var response = _authorRepository.Delete(id);
            if (response is false)
            {
                return ResultInfo.NotFound;
            }
            return ResultInfo.Deleted;
        }
       
    }
}
