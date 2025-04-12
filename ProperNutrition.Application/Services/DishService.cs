using ProperNutrition.Application.Mappers;
using ProperNutrition.Application.Models;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class DishService : IDishService
    {
        private readonly IDishesRepository _dishesRepository;

        public DishService(IDishesRepository dishesRepository)
        {
            _dishesRepository = dishesRepository;
        }

        public async Task<List<Dish>> GetPopularListAsync()
        {
            try
            {
                var dishes = (await _dishesRepository.GetAllAsync())!
                    .OrderByDescending(d => d.LikedBy.Count)
                    .ToList();

                if(dishes is not null)
                {
                    return dishes.Select(DishMapper.ToDomain).Take(dishes.Count < 5 ? dishes.Count : 5).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }
        public async Task<Dish?> GetAsync(Guid id)
        {
            try
            {
                var entity = await _dishesRepository.GetAsync(id);

                if (entity is not null)
                {
                    return DishMapper.ToDomain(entity);
                }

                return null;
            }
            catch
            {
                return null;
            }
        }

        public async Task<(double Calories, double Proteins, double Fats, double Carbs)> CalculateCPFC(Guid id)
        {
            var entity = await _dishesRepository.GetAsync(id);

            if (entity is not null)
            {
                var products = DishMapper.ToDomain(entity).Products;

                (double Calories, double Proteins, double Fats, double Carbs) = (0, 0, 0, 0);

                foreach (var product in products)
                {
                    Calories += product.Product.Calories * product.Weight / 100;
                    Proteins += product.Product.Proteins * product.Weight / 100;
                    Fats += product.Product.Fats * product.Weight / 100;
                    Carbs += product.Product.Carbs * product.Weight / 100;
                }

                return (Calories, Proteins, Fats, Carbs);
            }

            return (0, 0, 0, 0);
        }

        public async Task<string> AddAsync(Guid createdBydId, DishRequest model)
        {
            try
            {
                using var memoryStream = new MemoryStream();

                await model.Image.CopyToAsync(memoryStream);

                var imageBytes = memoryStream.ToArray();

                var entity = new DishEntity
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = imageBytes,
                    CreatedById = createdBydId,
                    CreatedAt = DateTime.UtcNow,
                    Products = model.Products.Select(p =>
                    {
                        return new DishProductEntity
                        {
                            ProductId = p.ProductId,
                            Weight = p.Weight
                        };
                    })
                    .ToList()
                };

                await _dishesRepository.AddAsync(entity);

                return string.Empty;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<string> UpdateAsync(Guid id, DishRequest model)
        {
            try
            {
                var entity = await _dishesRepository.GetAsync(id);

                if (entity is not null)
                {
                    using var memoryStream = new MemoryStream();

                    await model.Image.CopyToAsync(memoryStream);

                    var imageBytes = memoryStream.ToArray();

                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.Image = imageBytes;
                    entity.Products = model.Products.Select(p =>
                    {
                        return new DishProductEntity
                        {
                            ProductId = p.ProductId,
                            Weight = p.Weight
                        };
                    }).ToList();

                    await _dishesRepository.UpdateAsync(entity);

                    return string.Empty;
                }

                return "Такого блюда не существует!";
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
                var entity = await _dishesRepository.GetAsync(id);

                if (entity is not null)
                {
                    await _dishesRepository.DeleteAsync(entity);

                    return string.Empty;
                }

                return "Такого блюда не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        private double GetCalories(DishEntity entity)
        {
            if (entity is not null)
            {
                var calories = 0.0;

                foreach (var product in entity.Products)
                {
                    calories += product.Product.Calories;
                }

                return calories;
            }

            return 0;
        }

        public async Task<List<Dish>> GetLessCaloritAsync()
        {
            try
            {
                var entities = await _dishesRepository.GetAllAsync();

                if (entities is not null)
                {
                    var orderedEntities = entities.OrderByDescending(e => GetCalories(e)).ToList();

                    return orderedEntities.Select(DishMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Dish>> SearchAsync(string query)
        {
            try
            {
                var dishEntities = (await _dishesRepository.GetAllAsync())!
                .Where(d => d.Title.ToLower().Contains(query.ToLower()))
                .ToList();

                return dishEntities.Select(DishMapper.ToDomain).ToList();
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Dish>> GetAllAsync()
        {
            try
            {
                var dishEntities = await _dishesRepository.GetAllAsync();

                if (dishEntities is not null)
                {
                    return dishEntities.Select(DishMapper.ToDomain).ToList();
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
