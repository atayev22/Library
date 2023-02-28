using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string SecondName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public DateTime RegisterDate { get; set; }


    }
}
