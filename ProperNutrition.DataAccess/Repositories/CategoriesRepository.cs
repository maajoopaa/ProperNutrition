using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly ProperNutritionDbContext _context;

        public CategoriesRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryEntity>> GetAllAsync()
        {
            var entities = await _context.Categories
                .AsNoTracking()
                .ToListAsync();

            return entities;
        }

        public async Task<CategoryEntity?> GetAsync(Guid id)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
