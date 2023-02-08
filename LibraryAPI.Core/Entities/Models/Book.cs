using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Entities.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public DateTime PubDate { get; set; }
        public string Description { get; set; }


        //Relations
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Categorie Category { get; set; }
        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }
    }
}
