using LibraryAPI.Business.Services.Abstract;
using LibraryAPI.DataAccess.Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetCategoriesBrowse()
        {
            try
            {
                return Ok(_categoryService.GetCategoriesBrowse());
            }
            catch (Exception e)
            {

                return BadRequest(e.Source);
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult GetCategory(int id)
        {
            try
            {
                return Ok(_categoryService.GetCategoryById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult AddOrUpdateCategory([FromBody] Category model)
        {
            try
            {
                return Ok(_categoryService.AddOrUpdateCategory(model));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteCategory(int id)
        {
            try
            {
                return Ok(_categoryService.DeleteCategory(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Source);
            }
        }
    }
}

