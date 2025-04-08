using ProperNutrition.Domain.Models;

namespace ProperNutrition.Domain.Abstractions
{
    public interface IDishesRepository
    {
        Task AddAsync(Dish dish);
        Task<List<Dish>?> GetAllAsync();
        Task<Dish?> GetAsync(Guid id);
        Task RemoveAsync(Dish dish);
        Task UpdateAsync(Dish dish);
    }
}