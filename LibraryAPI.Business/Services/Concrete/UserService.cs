using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.UserDtos;
using LibraryAPI.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }

        public ResultInfo LogIn(UserRegisterDto user)
        {
            throw new NotImplementedException();
        }

        public ResultInfo RegisterUser(UserRegisterDto user)
        {
            throw new NotImplementedException();
        }
    }
}
