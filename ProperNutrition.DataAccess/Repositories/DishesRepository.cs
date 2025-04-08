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
    public class DishesRepository : IDishesRepository
    {
        private readonly ProperNutritionDbContext _context;

        public DishesRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<Dish?> GetAsync(Guid id)
        {
            var dishEntity = await _context.Dishes
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.Id == id);

            return dishEntity is null ? null : DishMapper.ToDomain(dishEntity);
        }

        public async Task<List<Dish>?> GetAllAsync()
        {
            var dishEntities = await _context.Dishes
                .ToListAsync();

            return dishEntities.Select(DishMapper.ToDomain).ToList();
        }

        public async Task AddAsync(Dish dish)
        {
            var dishEntity = DishMapper.ToEntity(dish);

            _context.Dishes.Add(dishEntity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Dish dish)
        {
            var dishEntity = DishMapper.ToEntity(dish);

            _context.Dishes.Update(dishEntity);

            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Dish dish)
        {
            var dishEntity = DishMapper.ToEntity(dish);

            _context.Dishes.Remove(dishEntity);

            await _context.SaveChangesAsync();
        }
    }
}
