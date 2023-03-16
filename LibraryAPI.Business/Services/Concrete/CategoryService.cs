using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.AuthorDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }
        public ResultInfo AddOrUpdateCategory(Category author)
        {
            throw new NotImplementedException();
        }

        public ResultInfo DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public Result GetCategoriesBrowse()
        {
            var result = new Result();

            var response = _categoryRepository.GetAll();

            result.Data = response;
            return result;
        }

        public Result GetCategoryById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
