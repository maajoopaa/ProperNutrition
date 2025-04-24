using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Mappers
{
    public static class DishProductMapper
    {
        public static DishProduct ToDomain(DishProductEntity entity) => new DishProduct
        {
            Product = ProductMapper.ToDomain(entity.Product),
            Weight = entity.Weight
        };

        public static DishProductEntity ToEntity(DishProduct domain) => new DishProductEntity
        {
            ProductId = domain.Product.Id,
            Weight = domain.Weight
        };
    }

}
