using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<DishListResponse> GetDishesAsync(Guid id, PaginationModel model);
    }
}