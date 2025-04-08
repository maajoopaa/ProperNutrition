using ProperNutrition.Domain.Models;

namespace ProperNutrition.DataAccess.Repositories
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