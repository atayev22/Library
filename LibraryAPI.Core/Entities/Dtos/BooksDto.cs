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
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public Authors? Author { get; set; }
        public Categories? Category { get; set; }
        public PublishingHouses? PublishingHouse { get; set; }
        public DateTime PubDate { get; set; }


    }
}
