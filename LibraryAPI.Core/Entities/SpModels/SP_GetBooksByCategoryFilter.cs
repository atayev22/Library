using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.SpModels
{
    [NotMapped]
   public class SP_GetBooksByCategoryFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public string AuthorFullName { get; set; }
        public string PublishingHouseAdress { get; set; }
        public DateTime PubDate { get; set; }
    }
}
