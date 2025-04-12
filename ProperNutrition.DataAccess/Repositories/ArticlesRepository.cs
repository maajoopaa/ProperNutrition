using Microsoft.EntityFrameworkCore;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.DataAccess.Repositories
{
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ProperNutritionDbContext _context;

        public ArticlesRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<ArticleEntity?> GetAsync(Guid id)
        {
            return await _context.Articles
                .FindAsync(id);
        }

        public async Task<List<ArticleEntity>?> GetAllAsync()
        {
            return await _context.Articles
                .ToListAsync();
        }

        public async Task AddAsync(ArticleEntity entity)
        {
            await _context.Articles
                .AddAsync(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task UpdateAsync(ArticleEntity entity)
        {
            _context.Articles
                .Update(entity);

            await _context
                .SaveChangesAsync();
        }

        public async Task DeleteAsync(ArticleEntity entity)
        {
            _context.Articles
                .Remove(entity);

            await _context
                .SaveChangesAsync();
        }
    }
}
