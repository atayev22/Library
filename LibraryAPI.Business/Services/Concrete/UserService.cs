using AutoMapper;
using Core.Utilities.Results;
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.UserDtos;
using LibraryAPI.Core.Entities.Models;
using LibraryAPI.DataAccess.Migrations;
using LibraryAPI.DataAccess.Repositories.Abstract;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryAPI.Business.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role,user.UserRole)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public ResultInfo LogIn(UserRegisterDto user)
        {
            throw new NotImplementedException();
        }

        public ResultInfo RegisterUser(UserRegisterDto user)
        {
            var response = _userRepository.GetUserByUserName(user.UserName);
            if (response is false)
            {
                CreatePassHash(user.Password, out byte[] passHash);               

                if (passHash is not null)
                {
                    string? hash = null;
                    foreach (byte h in passHash)
                    {
                        hash += h.ToString("x2");
                    }
                    user.Password = hash;
                    var data = _mapper.Map<User>(user);

                }
                return ResultInfo.Success;
            }

            return ResultInfo.AlreadyExists;
        }
        public void CreatePassHash(string password, out byte[] passHash)
        {
            SHA512 hmac = SHA512.Create();
            passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

        }

        public bool VerifyPassHash(string password, string passwordHash)
        {
            string? hashCheck = null;
            SHA512 hmac = SHA512.Create();

            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            foreach (byte b in hash)
            {
                hashCheck += b.ToString("x2");
            }
            if (hashCheck != passwordHash)
            {
                return false;
            }

            return true;
        }
    }
}
