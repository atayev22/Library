using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Business.Services.Concrete;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.DataAccess.Entities.Models;
using LibraryAPI.DataAccess.Utilities.EMail;
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
        [Authorize]
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

        [HttpGet]
        [Authorize]
        public IActionResult GetAuthorByNameFilter(string name)
        {
            try
            {
                return Ok(_authorService.GetAuthorByName(name));
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }
        [HttpGet("{id}")]
        [Authorize]
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddOrUpdateAuthor([FromBody] Author model)
        {
            try
            {
                return Ok(_authorService.AddOrUpdateAuthor(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteAuthor(int id)
        {
            try
            {
                return Ok(_authorService.DeleteAuthor(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
