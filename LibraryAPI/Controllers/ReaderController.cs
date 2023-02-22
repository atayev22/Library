using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.DataAccess.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public IActionResult GetReaderBrowse()
        {
            try
            {
                return Ok(_readerService.GetReadersBrowse());
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet]
        public IActionResult GetReaderByNameFilter(string name)
        {
            try
            {
                return Ok(_readerService.GetReaderByName(name));
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet]
        public IActionResult GetReaderByContactFilter(string contact)
        {
            try
            {
                return Ok(_readerService.GetReaderByContact(contact));
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetReader(int id)
        {
            try
            {
                return Ok(_readerService.GetReaderById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpPost]
        public ActionResult AddOrUpdateReader([FromBody] Reader model)
        {
            try
            {
                return Ok(_readerService.AddOrUpdateReader(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteReader(int id)
        {
            try
            {
                return Ok(_readerService.DeleteReader(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}
