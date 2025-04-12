﻿using ProperNutrition.Application.Mappers;
using ProperNutrition.Application.Models;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<string> AddAsync(ProductRequest model)
        {
            try
            {
                using var memoryStream = new MemoryStream();

                await model.Image.CopyToAsync(memoryStream);

                var imageBytes = memoryStream.ToArray();

                var entity = new ProductEntity
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = imageBytes,
                    Calories = model.Calories,
                    Proteins = model.Proteins,
                    Fats = model.Fats,
                    Carbs = model.Carbs
                };

                await _productsRepository.AddAsync(entity);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateAsync(Guid id, ProductRequest model)
        {
            try
            {
                var entity = await _productsRepository.GetAsync(id);

                if (entity is not null)
                {
                    using var memoryStream = new MemoryStream();

                    await model.Image.CopyToAsync(memoryStream);

                    var imageBytes = memoryStream.ToArray();

                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.Image = imageBytes;
                    entity.Calories = model.Calories;
                    entity.Proteins = model.Proteins;
                    entity.Fats = model.Fats;
                    entity.Carbs = model.Carbs;

                    await _productsRepository.UpdateAsync(entity);

                    return string.Empty;
                }

                return "Такого продукта не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> DeleteAsync(Guid id)
        {
            try
            {
                var entity = await _productsRepository.GetAsync(id);

                if (entity is not null)
                {
                    await _productsRepository.DeleteAsync(entity);

                    return string.Empty;
                }

                return "Такого продукта не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Product>> GetLessCaloritAsync()
        {
            try
            {
                var productEntities = (await _productsRepository.GetAllAsync())!
                .DistinctBy(p => p.Calories)
                .ToList();

                return productEntities.Select(ProductMapper.ToDomain).ToList();
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Product>> SearchAsync(string query)
        {
            try
            {
                var productEntities = (await _productsRepository.GetAllAsync())!
                .Where(p => p.Title.ToLower().Contains(query.ToLower()))
                .ToList();

                return productEntities.Select(ProductMapper.ToDomain).ToList();
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                var productEntities = await _productsRepository.GetAllAsync();

                if (productEntities is not null)
                {
                    return productEntities.Select(ProductMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }
    }
}
