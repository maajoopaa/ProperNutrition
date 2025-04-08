using ProperNutrition.Domain.Models;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task AddAsync(User user);
        Task DeleteAsync(User user);
        Task<List<User>?> GetAllAsync();
        Task<User?> GetAsync(Guid id);
        Task UpdateAsync(User user);
    }
}