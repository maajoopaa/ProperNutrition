using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;
using System.Security.Claims;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DishController : ControllerBase
    {
        private readonly IValidator<DishRequest> _validator;
        private readonly IDishService _dishService;

        public DishController(IValidator<DishRequest> validator, IDishService dishService)
        {
            _validator = validator;
            _dishService = dishService;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {
            var dishes = await _dishService.GetAllAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet]
        [Route("get-sort-list")]
        public async Task<IActionResult> GetSortList()
        {
            var dishes = await _dishService.GetLessCaloritAsync();

            return dishes is not null ? Ok(dishes) : BadRequest();
        }

        [HttpGet("get-dish/{id:guid}")]
        public async Task<IActionResult> GetDish(Guid id)
        {
            var dish = await _dishService.GetAsync(id);

            var cpfc = await _dishService.CalculateCPFC(id);

            return dish is not null ? Ok(new { dish, cpfc }) : BadRequest();
        }

        [HttpGet("search/{query}")]
        public async Task<IActionResult> Search(string query)
        {
            var dish = await _dishService.SearchAsync(query);

            return dish is not null ? Ok(dish) : BadRequest();
        }

        [HttpPost]
        [Route("add")]
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

        [HttpPut("update/{id:guid}")]
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

        [HttpDelete("delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var error = await _dishService.DeleteAsync(id);

            return string.IsNullOrEmpty(error) ? Ok("Удаление блюда прошло успешно!") : BadRequest(error);
        }
    }
}
