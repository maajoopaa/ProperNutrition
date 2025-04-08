using ProperNutrition.Domain.Models;

namespace ProperNutrition.Domain.Abstractions
{
    public interface IArticlesRepository
    {
        Task AddAsync(Article article);
        Task DeleteAsync(Article article);
        Task<List<Article>?> GetAllAsync();
        Task<Article?> GetAsync(Guid id);
        Task UpdateAsync(Article article);
    }
}