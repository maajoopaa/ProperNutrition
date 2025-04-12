using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public interface IUsersRepository
    {
        Task AddAsync(UserEntity userEntity);
        Task DeleteAsync(UserEntity userEntity);
        Task<List<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetAsync(Guid id);
        Task UpdateAsync(UserEntity userEntity);
    }
}