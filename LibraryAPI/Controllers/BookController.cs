
using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Core.Entities.Dtos.Book;
using LibraryAPI.Core.Entities.FnModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

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

        [HttpGet]
        public ActionResult<List<BookDto>> GetBooksBrowse()
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
        public ActionResult<List<FN_GetBooksByFilter>> GetAllBooksByFilter(string nameOrDescription)
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


        [HttpGet("{id}")]
        public ActionResult<BookDto> GetBook(int id)
        {
            try
            {
                return Ok(_booksService.GetBooksById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }


        //[HttpPut("{id}")]
        //public ActionResult UpdateBook([FromBody] BooksDto model)
        //{
        //    try
        //    {
        //        _booksService.UpdateBook(model);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Source);
        //    }
        //}

        //[HttpPost]
        //public ActionResult AddBook([FromBody] BooksDto model)
        //{
        //    try
        //    {
        //        _booksService.AddBook(model);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Source);
        //    }
        //}

        //[HttpDelete("{id}")]
        //public ActionResult Delete(int id)
        //{
        //    try
        //    {
        //        _booksService.Delete(id);
        //        return Ok();
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Source);
        //    }
        //}
    }
}
