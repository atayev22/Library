
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.BookDtos;
using LibraryAPI.Core.Entities.FnModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _booksService;

        public BookController(IBookService booksRepository)
        {
            _booksService = booksRepository;
        }

        [HttpGet,Authorize(Roles ="admin")]
        public ActionResult GetBooksBrowse()
        {
            try
            {
                return Ok(_booksService.GetBooksBrowse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpGet]
        public ActionResult GetAllBooksByFilter(string nameOrDescription)
        {
            try
            {
                return Ok(_booksService.GetBooksByFilter(nameOrDescription));
            }   
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }


        [HttpGet("{categoryId}")]
        public ActionResult GetBooksByCategoryFilter(int categoryId)
        {
            try
            {
                return Ok(_booksService.GetBooksByCategoryFilter(categoryId));
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }


        [HttpGet("{id}")]
        public ActionResult GetBook(int id)
        {
            try
            {
                return Ok(_booksService.GetBookById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }


        [HttpPost]
        public ActionResult AddOrUpdateBook([FromBody] BookAddOrUpdateDto model)
        {
            try
            {              
                return Ok(_booksService.AddOrUpdateBook(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            try
            {          
                return Ok(_booksService.DeleteBook(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
