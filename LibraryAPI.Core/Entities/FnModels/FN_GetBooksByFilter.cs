using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.FnModels
{
    public class FN_GetBooksByFilter
    {
        public int Id { get; set; }
        public string BookName { get; set; } = string.Empty;
    }
}
