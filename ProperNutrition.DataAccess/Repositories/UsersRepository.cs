using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ProperNutritionDbContext _context;

        public UsersRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<UserEntity?> GetAsync(Guid id)
        {
            return await _context.Users
                .FindAsync(id);
        }

        public async Task<List<UserEntity>> GetAllAsync()
        {
            return await _context.Users
                .ToListAsync();
        }

        public async Task AddAsync(UserEntity userEntity)
        {
            await _context.Users
                .AddAsync(userEntity);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(UserEntity userEntity)
        {
            _context.Users
                .Update(userEntity);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteAsync(UserEntity userEntity)
        {
            _context.Users
                .Remove(userEntity);

            await _context
                .SaveChangesAsync();
        }
    }
}
