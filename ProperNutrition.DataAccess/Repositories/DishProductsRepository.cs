using Microsoft.EntityFrameworkCore;
using ProperNutrition.DataAccess.Mappers;
using ProperNutrition.Domain.Abstractions;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Repositories
{
    public class DishProductsRepository : IDishProductsRepository
    {
        private readonly ProperNutritionDbContext _context;

        public DishProductsRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<DishProduct?> GetAsync(Guid dishId, Guid productId)
        {
            var entity = await _context.DishProducts
                .FirstOrDefaultAsync(dp => dp.DishId == dishId && dp.ProductId == productId);

            return entity is null ? null : DishProductMapper.ToDomain(entity);
        }

        public async Task<List<DishProduct>> GetByDishAsync(Guid dishId)
        {
            var entities = await _context.DishProducts
                .Where(dp => dp.DishId == dishId)
                .ToListAsync();

            return entities.Select(DishProductMapper.ToDomain).ToList();
        }

        public async Task AddAsync(DishProduct dishProduct)
        {
            var entity = DishProductMapper.ToEntity(dishProduct);

            _context.DishProducts.Add(entity);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid dishId, Guid productId)
        {
            var entity = await _context.DishProducts
                .FirstOrDefaultAsync(dp => dp.DishId == dishId && dp.ProductId == productId);

            if (entity != null)
            {
                _context.DishProducts.Remove(entity);

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(DishProduct dishProduct)
        {
            var entity = DishProductMapper.ToEntity(dishProduct);

            _context.DishProducts.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
