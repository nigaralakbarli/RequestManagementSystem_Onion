using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RequestManagementSystem.Application.DTOs.Category.Request;
using RequestManagementSystem.Application.DTOs.Category.Response;
using RequestManagementSystem.Application.Interfaces;

namespace RequestManagementSystem.WebApi.Controllers
{
    [Route("Category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route("GetAll")]
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok(_categoryService.GetCategories());
        }

        [Route("GetById")]
        [HttpGet]
        public IActionResult GetCategory(int categoryId)
        {
            return Ok(_categoryService.GetCategoryById(categoryId));
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult CreateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            if (!_categoryService.CreateCategory(categoryRequestDTO))
            {
                return BadRequest();
            }
            return Ok("Successfully created");
        }

        [Route("Update")]
        [HttpPut]
        public IActionResult UpdateCategory(CategoryRequestDTO categoryRequestDTO)
        {
            if (_categoryService.UpdateCategory(categoryRequestDTO))
            {
                return Ok("Successfully updated");
            }
            return NotFound();
        }

        [Route("Delete")]
        [HttpDelete]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (_categoryService.DeleteCategory(categoryId))
            {
                return Ok("Successfully deleted");
            }
            return NotFound();
        }

    }
}
