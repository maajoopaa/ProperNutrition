using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public class DishProductsRepository : IDishProductsRepository
    {
        private readonly ProperNutritionDbContext _context;

        public DishProductsRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<DishProductEntity?> GetAsync(Guid dishId, Guid productId)
        {
            return await _context.DishProducts
                .FindAsync(dishId, productId);
        }

        public async Task<List<DishProductEntity>?> GetAllAsync()
        {
            return await _context.DishProducts
                .ToListAsync();
        }

        public async Task AddAsync(DishProductEntity entity)
        {
            await _context.DishProducts
                .AddAsync(entity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(DishProductEntity entity)
        {
            _context.DishProducts
                .Update(entity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(DishProductEntity entity)
        {
            _context.DishProducts
                .Remove(entity);

            await _context.SaveChangesAsync();
        }
    }
}
