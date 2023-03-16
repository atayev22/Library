using Core.Utilities.Results;
using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface ICategoryService
    {
        Result GetCategoriesBrowse();
        Result GetCategoryById(int id);
        ResultInfo AddOrUpdateCategory(Category author);
        ResultInfo DeleteCategory(int id);
    }
}
