﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Core.Entities.Dtos.UserDtos
{
    public class UserDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UseRole { get; set; }
    }
}
