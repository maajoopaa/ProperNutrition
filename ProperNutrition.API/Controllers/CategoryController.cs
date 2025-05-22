using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/category")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _categoryService.GetCategoriesAsync();

            return Ok(response);
        }

        [HttpPost("{id:guid}/dishes")]
        public async Task<IActionResult> GetDishes(Guid id, [FromBody] PaginationModel model)
        {
            var response = await _categoryService.GetDishesAsync(id,model);

            return Ok(response);    
        }
    }
}
