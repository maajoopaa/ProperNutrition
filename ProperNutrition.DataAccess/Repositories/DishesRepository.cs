using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public class DishesRepository : IDishesRepository
    {
        private readonly ProperNutritionDbContext _context;

        public DishesRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<DishEntity?> GetAsync(Guid id)
        {
            return await _context.Dishes
                .FindAsync(id);
        }

        public async Task<List<DishEntity>?> GetAllAsync()
        {
            return await _context.Dishes
                .ToListAsync();
        }

        public async Task AddAsync(DishEntity entity)
        {
            await _context.Dishes
                .AddAsync(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(DishEntity entity)
        {
            _context.Dishes
                .Update(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteAsync(DishEntity entity)
        {
            _context.Dishes
                .Remove(entity);

            await _context
                .SaveChangesAsync();
        }
    }
}
