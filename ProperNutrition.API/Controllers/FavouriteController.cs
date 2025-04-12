using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Services;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [HttpGet]
        [Route("get-list")]
        public async Task<IActionResult> GetList()
        {
            var userId = GetUserId();

            var favourite = await _favouriteService.GetAllAsync(userId);

            return favourite is not null ? Ok(favourite) : BadRequest();
        }

        [HttpPost("like/{dishId:guid}")]
        public async Task<IActionResult> Like(Guid dishId)
        {
            var userId = GetUserId();

            var error = await _favouriteService.LikeAsync(userId, dishId);

            return string.IsNullOrEmpty(error) ? Ok("Блюдо успешно добавлено в избранное!") : BadRequest(error);
        }

        [HttpDelete("unlike/{dishId:guid}")]
        public async Task<IActionResult> Unlike(Guid dishId)
        {
            var userId = GetUserId();

            var error = await _favouriteService.UnlikeAsync(userId, dishId);

            return string.IsNullOrEmpty(error) ? Ok("Блюдо успешно удалено из избранного!") : BadRequest(error);
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirst("userId")?.Value ?? string.Empty);
        }
    }
}
