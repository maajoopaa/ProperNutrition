using ProperNutrition.Domain.Models;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task AddAsync(Product product);
        Task DeleteAsync(Product product);
        Task<List<Product>?> GetAllAsync();
        Task<Product?> GetAsync(Guid id);
        Task UpdateAsync(Product product);
    }
}