using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Entities.Models
{
    public class Books
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public DateTime PubDate { get; set; }
        public string Description { get; set; } = string.Empty;


        //Relations
        public int AuthorId { get; set; }
        public Authors? Author { get; set; }
        public int CategoryId { get; set; }
        public Categories? Category { get; set; }
        public int PublishingHouseId { get; set; }
        public PublishingHouses? PublishingHouse { get; set; }
    }
}
