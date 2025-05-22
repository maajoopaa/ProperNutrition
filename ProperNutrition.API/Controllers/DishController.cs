using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;
using ProperNutrition.DataAccess;
using System.Security.Claims;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/dish")]
    public class DishController : ControllerBase
    {
        private readonly IValidator<DishRequest> _validator;
        private readonly IDishService _dishService;
        private readonly ProperNutritionDbContext context;

        public DishController(IValidator<DishRequest> validator, IDishService dishService, ProperNutritionDbContext context)
        {
            _validator = validator;
            _dishService = dishService;
            this.context = context;
        }

        [HttpPost]
        [Route("list")]
        public async Task<IActionResult> GetList([FromBody] PaginationModel model)
        {
            var dishes = await _dishService.GetAllAsync(model);

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("popular-list")]
        public async Task<IActionResult> GetPopularList()
        {
            var dishes = await _dishService.GetPopularListAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("calories-sort")]
        public async Task<IActionResult> GetCaloriesSort()
        {
            var dishes = await _dishService.GetLessCaloritAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("proteins-sort")]
        public async Task<IActionResult> GetProteinsSort()
        {
            var dishes = await _dishService.GetLessProteinsAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("carbs-sort")]
        public async Task<IActionResult> GetCarbsSort()
        {
            var dishes = await _dishService.GetLessCarbsAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("fats-sort")]
        public async Task<IActionResult> GetFatsSort()
        {
            var dishes = await _dishService.GetLessFatsAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDish(Guid id)
        {
            var dish = await _dishService.GetAsync(id);


            return dish is not null ? Ok(dish) : BadRequest();
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var dish = await _dishService.SearchAsync(query);

            return dish is not null ? Ok(dish) : BadRequest();
        }

        [Authorize]
        [HttpPost("")]
        public async Task<IActionResult> Add([FromBody] DishRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var userId = Guid.Parse(User.FindFirst("userId")?.Value ?? string.Empty);

            var error = await _dishService.AddAsync(userId,model);

            return string.IsNullOrEmpty(error) ? Ok("Добавление блюда прошло успешно!") : BadRequest(error);
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] DishRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var error = await _dishService.UpdateAsync(id, model);

            return string.IsNullOrEmpty(error) ? Ok("Обновление блюда прошло успешно!") : BadRequest(error);
        }

        [Authorize]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var error = await _dishService.DeleteAsync(id);

            return string.IsNullOrEmpty(error) ? Ok("Удаление блюда прошло успешно!") : BadRequest(error);
        }
    }
}
