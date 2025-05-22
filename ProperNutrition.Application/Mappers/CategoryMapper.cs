using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Mappers
{
    public class CategoryMapper
    {
        public static Category ToDomain(CategoryEntity entity) => new Category
        {
            Id = entity.Id,
            Title = entity.Title,
            Dishes = entity.Dishes.Select(DishMapper.ToDomain).ToList()
        };
    }
}
