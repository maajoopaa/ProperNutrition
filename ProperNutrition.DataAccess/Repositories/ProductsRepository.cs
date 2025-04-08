using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.DataAccess.Entities;
using ProperNutrition.DataAccess.Mappers;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProperNutritionDbContext _context;

        public ProductsRepository(ProperNutritionDbContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetAsync(Guid id)
        {
            var productEntity = await _context.Products
                    .AsNoTracking()
                    .FirstOrDefaultAsync(pe => pe.Id == id);

            if (productEntity is not null)
            {
                return ProductMapper.ToDomain(productEntity);
            }

            return null;
        }

        public async Task<List<Product>?> GetAllAsync()
        {
            var productEntities = await _context.Products
                    .AsNoTracking()
                    .ToListAsync();

            if (productEntities is not null)
            {
                return productEntities.Select(ProductMapper.ToDomain).ToList();
            }

            return null;
        }

        public async Task AddAsync(Product product)
        {
            var productEntity = ProductMapper.ToEntity(product);

            _context.Products.Add(productEntity);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            var productEntity = ProductMapper.ToEntity(product);

            _context.Products.Update(productEntity);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Product product)
        {
            var productEntity = ProductMapper.ToEntity(product);

            _context.Products.Remove(productEntity);

            await _context.SaveChangesAsync();
        }
    }
}
