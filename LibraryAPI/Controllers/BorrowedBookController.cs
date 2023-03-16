using LibraryAPI.Business.Services.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BorrowedBookController : ControllerBase
    {
        private readonly IBorrowedBookService _borrowBookService;

        public BorrowedBookController(IBorrowedBookService borrowBookService)
        {
            _borrowBookService = borrowBookService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetBorrowBooksBrowse()
        {
            try
            {
                return Ok(_borrowBookService.GetBorrowedBooksBrowse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
        [HttpGet]
        [Authorize]
        public ActionResult GetBorrowBooksByBookId(int bookId)
        {
            try
            {
                return Ok(_borrowBookService.GetBorrowedBooksByBookId(bookId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetBorrowBooksByReaderId(int readerId)
        {
            try
            {
                return Ok(_borrowBookService.GetBorrowedBooksByReaderId(readerId));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetBorrowBooksByDateInterval(DateTime firstDate,DateTime secondDate)
        {
            try
            {
                return Ok(_borrowBookService.GetBorrowedBooksByDateInterval(firstDate, secondDate));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

    }
}
