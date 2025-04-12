using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IArticlesRepository
    {
        Task AddAsync(ArticleEntity entity);
        Task DeleteAsync(ArticleEntity entity);
        Task<List<ArticleEntity>?> GetAllAsync();
        Task<ArticleEntity?> GetAsync(Guid id);
        Task UpdateAsync(ArticleEntity entity);
    }
}