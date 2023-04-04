using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.AuthorDtos;
using LibraryAPI.Core.Entities.Dtos.CategoryDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Repositories.Abstract;
using LibraryAPI.DataAccess.Repositories.Concrete;
using LibraryAPI.DataAccess.Utilities.Tools.EfCore;
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
        public ResultInfo AddOrUpdateCategory(Category category)
        {
            var result = new Result();
            if (category.Id is 0)
            {
                _categoryRepository.Add(category);
            }
            else
            {
                _categoryRepository.Update(category);
            }

            if (category is null)
            {
                return ResultInfo.NotImplemented;
            }

            return ResultInfo.Success;
        }

        public ResultInfo DeleteCategory(int id)
        {
            var response = _categoryRepository.Delete(id);
            if (response is false)
            {
                return ResultInfo.NotFound;
            }
            return ResultInfo.Deleted;
        }

        public Result GetCategoriesBrowse(PageHandler paginator)
        {
            var result = new Result();
            var response = _categoryRepository.GetCategoriesBrowse(paginator,out int pageCount);

            var data = new CategoriesBrowseDto
            {
                Categories = response,
                PageCount = pageCount
            };

            using var date = new CategoriesBrowseDto()

            result.Data = data;
            return result;
        }

        public Result GetCategoryById(int id)
        {
            var result = new Result();

            var category = _categoryRepository.Get(id);

            result.Data = category;
            return result;
        }
    }
}
