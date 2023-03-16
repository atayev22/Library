using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Dtos.BookDtos
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public Author Author { get; set; }
        public Category Category { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
        public DateTime PubDate { get; set; }


    }
}
