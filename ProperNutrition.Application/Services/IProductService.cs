﻿using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IProductService
    {
        Task<string> AddAsync(ProductRequest model);
        Task<string> DeleteAsync(Guid id);
        Task<List<Product>> GetAllAsync();
        Task<List<Product>> GetLessCaloritAsync();
        Task<List<Product>> SearchAsync(string query);
        Task<string> UpdateAsync(Guid id, ProductRequest model);
    }
}