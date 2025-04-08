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
    public class ArticlesRepository : IArticlesRepository
    {
        private readonly ProperNutritionDbContext _context;

        public ArticlesRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<Article?> GetAsync(Guid id)
        {
            var articleEntity = await _context.Articles
                .AsNoTracking()
                .FirstOrDefaultAsync(ae => ae.Id == id);

            return articleEntity is null ? null : ArticleMapper.ToDomain(articleEntity);
        }

        public async Task<List<Article>?> GetAllAsync()
        {
            var articleEntities = await _context.Articles
                .AsNoTracking()
                .ToListAsync();

            return articleEntities.Select(ArticleMapper.ToDomain).ToList();
        }

        public async Task AddAsync(Article article)
        {
            var articleEntity = ArticleMapper.ToEntity(article);

            _context.Articles.Add(articleEntity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Article article)
        {
            var articleEntity = ArticleMapper.ToEntity(article);

            _context.Articles.Update(articleEntity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Article article)
        {
            var articleEntity = ArticleMapper.ToEntity(article);

            _context.Articles.Remove(articleEntity);

            await _context.SaveChangesAsync();
        }
    }
}
