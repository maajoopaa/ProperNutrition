using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Services;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/favourite")]
    [Authorize]
    public class FavouriteController : ControllerBase
    {
        private readonly IFavouriteService _favouriteService;

        public FavouriteController(IFavouriteService favouriteService)
        {
            _favouriteService = favouriteService;
        }

        [Authorize]
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> GetList()
        {
            var userId = GetUserId();

            var favourite = await _favouriteService.GetAllAsync(userId);

            return favourite is not null ? Ok(favourite) : BadRequest();
        }

        [Authorize]
        [HttpPost("{dishId:guid}/like")]
        public async Task<IActionResult> Like(Guid dishId)
        {
            var userId = GetUserId();

            var error = await _favouriteService.LikeAsync(userId, dishId);

            return string.IsNullOrEmpty(error) ? Ok("Избранное успешно изменено!") : BadRequest(error);
        }

        private Guid GetUserId()
        {
            return Guid.Parse(User.FindFirst("userId")?.Value ?? string.Empty);
        }
    }
}
