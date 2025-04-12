using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IArticleService
    {
        Task<string> AddAsync(ArticleRequest model);
        Task<string> DeleteAsync(Guid id);
        Task<string> UpdateAsync(Guid id, ArticleRequest model);
        Task<List<Article>> GetAllAsync();
    }
}