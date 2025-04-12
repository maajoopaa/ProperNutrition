using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task AddAsync(ProductEntity entity);
        Task DeleteAsync(ProductEntity entity);
        Task<List<ProductEntity>?> GetAllAsync();
        Task<ProductEntity?> GetAsync(Guid id);
        Task UpdateAsync(ProductEntity entity);
    }
}