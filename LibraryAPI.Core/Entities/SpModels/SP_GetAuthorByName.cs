using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.SpModels
{

    [NotMapped]
    public class SP_GetAuthorByName
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
