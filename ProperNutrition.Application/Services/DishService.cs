using Microsoft.Extensions.Logging;
using ProperNutrition.Application.Mappers;
using ProperNutrition.Application.Models;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using Serilog;
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
                    .Where(x => x.CreatedBy.IsAdmin == 1)
                    .OrderByDescending(d => d.LikedBy.Count)
                    .ToList();

                if (dishes is not null)
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
                var entity = new DishEntity
                {
                    Title = model.Title,
                    Description = model.Description,
                    Image = Convert.FromBase64String(model.Image),
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
                    .ToList(),
                    CategoryId = model.CategoryId,
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
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.Image = Convert.FromBase64String(model.Image);
                    entity.Products.Clear();
                    entity.Products = model.Products.Select(p =>
                    {
                        return new DishProductEntity
                        {
                            ProductId = p.ProductId,
                            Weight = p.Weight
                        };
                    }).ToList();
                    entity.CategoryId = model.CategoryId;

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

                Log.Information("Calories {calories}", calories);

                return calories;
            }

            return 0;
        }

        private double GetProteins(DishEntity entity)
        {
            if (entity is not null)
            {
                var proteins = 0.0;

                foreach (var product in entity.Products)
                {
                    proteins += product.Product.Proteins;
                }

                Log.Information("Proteins {proteins}", proteins);

                return proteins;
            }

            return 0;
        }

        private double GetFats(DishEntity entity)
        {
            if (entity is not null)
            {
                var calories = 0.0;

                foreach (var product in entity.Products)
                {
                    calories += product.Product.Fats;
                }

                Log.Information("Fats {calories}", calories);

                return calories;
            }

            return 0;
        }

        private double GetCarbs(DishEntity entity)
        {
            if (entity is not null)
            {
                var calories = 0.0;

                foreach (var product in entity.Products)
                {
                    calories += product.Product.Carbs;
                }

                Log.Information("Carbs {calories}", calories);

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
                    var orderedEntities = entities.OrderBy(e => GetCalories(e)).ToList();

                    return orderedEntities.Select(DishMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Dish>> GetLessProteinsAsync()
        {
            try
            {
                var entities = await _dishesRepository.GetAllAsync();

                if (entities is not null)
                {
                    var orderedEntities = entities.OrderBy(e => GetProteins(e)).ToList();

                    return orderedEntities.Select(DishMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Dish>> GetLessCarbsAsync()
        {
            try
            {
                var entities = await _dishesRepository.GetAllAsync();

                if (entities is not null)
                {
                    var orderedEntities = entities.OrderBy(e => GetCarbs(e)).ToList();

                    return orderedEntities.Select(DishMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }

        public async Task<List<Dish>> GetLessFatsAsync()
        {
            try
            {
                var entities = await _dishesRepository.GetAllAsync();

                if (entities is not null)
                {
                    var orderedEntities = entities.OrderBy(e => GetFats(e)).ToList();

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

        public async Task<DishListResponse> GetAllAsync(PaginationModel model)
        {
            try
            {
                var dishEntities = await _dishesRepository.GetAllAsync();

                if (dishEntities is not null)
                {
                    var count = dishEntities.Count;

                    var result = dishEntities
                        .Where(x => x.CreatedBy.IsAdmin == 1)
                        .Skip((model.Page - 1) * model.PageSize)
                        .Take(model.PageSize)
                        .Select(DishMapper.ToDomain)
                        .ToList();

                    return new DishListResponse
                    {
                        Dishes = result,
                        Total = count
                    };
                }

                return new DishListResponse();
            }
            catch
            {
                return new DishListResponse();
            }

            //var dishes = (await _dishesRepository.GetAllAsync())!
            //    .Where(x => x.CreatedBy.IsAdmin == 1);

            //if(dishes is not null)
            //{
            //    return dishes.Select(DishMapper.ToDomain).ToList();
            //}

            //return [];
        }
    }
}
