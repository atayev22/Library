using LibraryApi.BaseLog.Entities.Dtos;
using LibraryApi.BaseLog.Infrastructure.Repositories.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBooksRepository _booksRepository;

        public BooksController(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        [HttpGet]
        public ActionResult<List<BooksDto>> GetAllBooks()
        {
            try
            {
                return Ok(_booksRepository.GetAllBooks());
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<BooksDto> GetBook(int id)
        {
            try
            {
                return Ok(_booksRepository.GetBook(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }


        [HttpPut("{id}")]
        public ActionResult UpdateBook([FromBody] BooksDto model)
        {
            try
            {
               _booksRepository.UpdateBook(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpPost]
        public ActionResult AddBook([FromBody] BooksDto model)
        {
            try
            {
                _booksRepository.AddBook(model);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _booksRepository.Delete(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
