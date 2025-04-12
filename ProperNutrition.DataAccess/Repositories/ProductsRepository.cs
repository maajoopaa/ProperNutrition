using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProperNutritionDbContext _context;

        public ProductsRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity?> GetAsync(Guid id)
        {
            return await _context.Products
                .FindAsync(id);
        }

        public async Task<List<ProductEntity>?> GetAllAsync()
        {
            return await _context.Products
                .ToListAsync();
        }

        public async Task AddAsync(ProductEntity entity)
        {
            await _context.Products
                .AddAsync(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductEntity entity)
        {
            _context.Products
                .Update(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductEntity entity)
        {
            _context.Products
                .Remove(entity);

            await _context
                .SaveChangesAsync();
        }
    }
}
