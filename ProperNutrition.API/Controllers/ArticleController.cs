using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly IValidator<ArticleRequest> _validator;

        public ArticleController(IArticleService articleService, IValidator<ArticleRequest> validator)
        {
            _articleService = articleService;
            _validator = validator;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {
            var articles = await _articleService.GetAllAsync();

            return articles is not null ? Ok(articles) : BadRequest();
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add([FromBody] ArticleRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var error = await _articleService.AddAsync(model);

            return string.IsNullOrEmpty(error) ? Ok("Добавление новости прошло успешно!") : BadRequest(error); 
        }

        [HttpPut("update/{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ArticleRequest model)
        {
            try
            {
                _validator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var error = await _articleService.UpdateAsync(id, model);

            return string.IsNullOrEmpty(error) ? Ok("Обновление новости прошло успешно!") : BadRequest(error);
        }

        [HttpDelete("delete/{id:guid}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var error = await _articleService.DeleteAsync(id);

            return string.IsNullOrEmpty(error) ? Ok("Удаление новости прошло успешно!") : BadRequest(error);
        }
    }
}
