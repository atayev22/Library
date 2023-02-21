using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.SpModels
{
    public class SP_GetAuthorByName
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
