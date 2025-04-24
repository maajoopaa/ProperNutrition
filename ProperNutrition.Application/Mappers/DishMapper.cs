using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System.ComponentModel;

namespace ProperNutrition.Application.Mappers
{
    public static class DishMapper
    {
        public static Dish ToDomain(DishEntity entity) => new Dish
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Image = Convert.ToBase64String(entity.Image),
            CreatedAt = entity.CreatedAt,
            CreatedBy = UserMapper.ToDomainBasic(entity.CreatedBy),
            Products = entity.Products.Select(DishProductMapper.ToDomain).ToList()
        };

        public static DishEntity ToEntity(Dish domain)
        {
            var dishEntity = new DishEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description,
                Image = Convert.FromBase64String(domain.Image),
                CreatedAt = domain.CreatedAt,
                CreatedById = domain.CreatedBy.Id,
                Products = domain.Products.Select(DishProductMapper.ToEntity).ToList()
            };

            return dishEntity;
        }
    }

}
