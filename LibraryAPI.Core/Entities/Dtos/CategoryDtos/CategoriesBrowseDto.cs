using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Dtos.CategoryDtos
{
    public class CategoriesBrowseDto
    {
        public IEnumerable<Category> Categories { get; set; }
        public int PageCount { get; set; }
    }
}
