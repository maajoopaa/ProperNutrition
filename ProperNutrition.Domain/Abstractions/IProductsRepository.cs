using ProperNutrition.Domain.Models;

namespace ProperNutrition.Domain.Abstractions
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