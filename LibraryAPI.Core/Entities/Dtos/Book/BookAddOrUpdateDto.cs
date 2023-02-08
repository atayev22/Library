using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Dtos.Book
{
    public class BookAddOrUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public DateTime PubDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public int PublishingHouseId { get; set; }
    }
}
