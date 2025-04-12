using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IDishProductsRepository
    {
        Task AddAsync(DishProductEntity entity);
        Task DeleteAsync(DishProductEntity entity);
        Task<List<DishProductEntity>?> GetAllAsync();
        Task<DishProductEntity?> GetAsync(Guid dishId, Guid productId);
        Task UpdateAsync(DishProductEntity entity);
    }
}