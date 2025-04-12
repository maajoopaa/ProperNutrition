using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IDishesRepository
    {
        Task AddAsync(DishEntity entity);
        Task DeleteAsync(DishEntity entity);
        Task<List<DishEntity>?> GetAllAsync();
        Task<DishEntity?> GetAsync(Guid id);
        Task UpdateAsync(DishEntity entity);
    }
}