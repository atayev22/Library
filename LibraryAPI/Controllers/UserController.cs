using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.UserDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult RegisterUser(UserRegisterDto user)
        {
            try
            {
                return Ok(_userService.RegisterUser(user));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
