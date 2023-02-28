using LibraryAPI.Core.Entities.Dtos.UserDtos;
using LibraryAPI.Core.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Abstract
{
    public interface IUserService
    {
        ResultInfo RegisterUser(UserRegisterDto user);
        string LogIn(UserLogInDto user);
        string CreateToken(UserDto user);
        void CreatePassHash(string password, out byte[] passwordHash);
        bool VerifyPassHash(string pass, string passHash);
    }
}
