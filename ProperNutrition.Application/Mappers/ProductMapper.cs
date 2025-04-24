using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Mappers
{
    public static class ProductMapper
    {
        public static Product ToDomain(ProductEntity entity) => new Product
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Calories = entity.Calories,
            Proteins = entity.Proteins,
            Fats = entity.Fats,
            Carbs = entity.Carbs,
            Image = Convert.ToBase64String(entity.Image),
        };

        public static ProductEntity ToEntity(Product domain) => new ProductEntity
        {
            Id = domain.Id,
            Title = domain.Title,
            Description = domain.Description,
            Calories = domain.Calories,
            Proteins = domain.Proteins,
            Fats = domain.Fats,
            Carbs = domain.Carbs,
            Image = Convert.FromBase64String(domain.Image)
        };
    }

}
