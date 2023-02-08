using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Entities.Models
{
    public class BorrowedBook
    {
        public int Id { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }


        //Relations
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
