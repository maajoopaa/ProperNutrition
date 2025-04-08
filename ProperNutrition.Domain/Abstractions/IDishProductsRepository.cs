using ProperNutrition.Domain.Models;

namespace ProperNutrition.Domain.Abstractions
{
    public interface IDishProductsRepository
    {
        Task AddAsync(DishProduct dishProduct);
        Task<DishProduct?> GetAsync(Guid dishId, Guid productId);
        Task<List<DishProduct>> GetByDishAsync(Guid dishId);
        Task RemoveAsync(Guid dishId, Guid productId);
        Task UpdateAsync(DishProduct dishProduct);
    }
}