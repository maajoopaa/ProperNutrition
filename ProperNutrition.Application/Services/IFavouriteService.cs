using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IFavouriteService
    {
        Task<List<Dish>> GetAllAsync(Guid userId);
        Task<string> LikeAsync(Guid userId, Guid dishId);
        Task<string> UnlikeAsync(Guid userId, Guid dishId);
    }
}