using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.Business.Services.Concrete;
using LibraryAPI.Core.Entities.Dtos.BorrowBookDtos;
using LibraryAPI.DataAccess.Entities.Models;
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
        public ActionResult SendMailToReader(int readerId)
        {
            try
            {
                return Ok(_borrowBookService.SendMailToReader(readerId));
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

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddOrUpdateBorrowedBook(BorrowedBookDto model)
        {
            try
            {
                return Ok(_borrowBookService.AddOrUpdateBorrowedBook(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteBorrowedBook(int id)
        {
            try
            {
                return Ok(_borrowBookService.DeleteBorrowedBook(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

    }
}
