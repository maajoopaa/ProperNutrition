using ProperNutrition.Application.Mappers;
using ProperNutrition.Application.Models;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoriesRepository _categoriesRepository;

        public CategoryService(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var entities = await _categoriesRepository.GetAllAsync();

                return entities.Select(CategoryMapper.ToDomain).ToList();
            }
            catch
            {
                return [];
            }
        }

        public async Task<DishListResponse> GetDishesAsync(Guid id, PaginationModel model)
        {
            try
            {
                var entity = await _categoriesRepository.GetAsync(id);

                if (entity is not null)
                {
                    return new DishListResponse
                    {
                        Dishes = entity.Dishes.Select(DishMapper.ToDomain)
                            .Skip((model.Page - 1) * model.PageSize)
                            .Take(model.PageSize)
                            .ToList(),
                        Total = entity.Dishes.Count()
                    };
                }

                return new DishListResponse();
            }
            catch
            {
                return new DishListResponse();
            }
        }
    }
}
