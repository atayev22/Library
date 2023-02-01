using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Entities.Models
{
    public class BorrowedBooks
    {
        public int Id { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }


        //Relations
        public int BookId { get; set; }
        public Books? Book { get; set; }
        public int ReaderId { get; set; }
        public Readers? Reader { get; set; }
    }
}
