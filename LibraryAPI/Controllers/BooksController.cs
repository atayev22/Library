using LibraryApi.BaseLog.Entities.Dtos;
using LibraryAPI.Business.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksService _booksService;

        public BooksController(IBooksService booksRepository)
        {
            _booksService = booksRepository;
        }

        [HttpGet]
        public ActionResult<List<BooksDto>> GetAllBooks()
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
        public ActionResult<List<BooksDto>> GetAllBooksByFilter(string nameOrDescription)
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

        //[HttpGet("{id}")]
        //public ActionResult<BooksDto> GetBook(int id)
        //{
        //    try
        //    {
        //        return Ok(_booksService.GetBook(id));
        //    }
        //    catch (Exception e)
        //    {
        //        return BadRequest(e.Source);
        //    }
        //}


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
