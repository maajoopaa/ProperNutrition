using ProperNutrition.DataAccess.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Mappers
{
    public static class DishProductMapper
    {
        public static DishProduct ToDomain(DishProductEntity entity) => new DishProduct
        {
            Product = ProductMapper.ToDomain(entity.Product),
            Dish = DishMapper.ToDomain(entity.Dish),
            Weight = entity.Weight
        };

        public static DishProductEntity ToEntity(DishProduct domain) => new DishProductEntity
        {
            DishId = domain.Dish.Id,
            ProductId = domain.Product.Id,
            Weight = domain.Weight
        };
    }

}
