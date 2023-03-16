using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Dtos.BorrowBookDtos
{
    public class GetBorrowedBooksByDateIntervalDto
    {
        public int Id { get; set; }
        public DateTime LendDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Book Book { get; set; }
        public Reader Reader { get; set; }
    }
}
