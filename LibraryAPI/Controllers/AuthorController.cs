using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Business.Services.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthorController : ControllerBase 
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAuthorBrowse()
        {
            try
            {
                return Ok(_authorService.GetAuthorsBrose());
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetAuthor(int id)
        {
            try
            {
                return Ok(_authorService.GetAuthorById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
