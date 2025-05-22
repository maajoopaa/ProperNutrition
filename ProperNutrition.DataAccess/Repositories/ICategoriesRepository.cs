using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface ICategoriesRepository
    {
        Task<List<CategoryEntity>> GetAllAsync();
        Task<CategoryEntity?> GetAsync(Guid id);
    }
}