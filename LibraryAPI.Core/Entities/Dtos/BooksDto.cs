using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApi.BaseLog.Entities.Dtos
{
    public class BooksDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public int PublishingHouseId { get; set; }
        public DateTime PubDate { get; set; }


    }
}
