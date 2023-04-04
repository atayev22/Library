using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.DataAccess.Utilities.Tools.EfCore
{
    public class PageHandler
    {
        public int Page { get; set; }
        public int VisibleItemCount { get; set; }
    }
}
