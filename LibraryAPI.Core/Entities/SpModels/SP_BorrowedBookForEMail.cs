using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.SpModels
{
    [NotMapped]
    public class SP_BorrowedBookForEMail
    {
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public string BookName { get; set; }
    }
}
