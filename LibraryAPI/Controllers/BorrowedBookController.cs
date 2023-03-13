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
        private readonly IBorrowBookService _borrowBookService;

        public BorrowedBookController(IBorrowBookService borrowBookService)
        {
            _borrowBookService = borrowBookService;
        }

        [HttpGet]
        [Authorize]
        public ActionResult GetBorrowBooksBrowse()
        {
            try
            {
                return Ok(_borrowBookService.GetBorrowBooksBrowse());
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
