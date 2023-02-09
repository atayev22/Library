﻿using LibraryAPI.DataAccess.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.SpModels
{
    public class SP_GetBooksByCategoryFilter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public int PageCount { get; set; }
        public string Description { get; set; }
        public string AuthorName { get; set; }
        public string PublishingHouseName { get; set; }
        public DateTime PubDate { get; set; }
    }
}