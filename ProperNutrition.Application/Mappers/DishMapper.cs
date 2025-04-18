﻿using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Mappers
{
    public static class DishMapper
    {
        public static Dish ToDomain(DishEntity entity) => new Dish
        {
            Id = entity.Id,
            Title = entity.Title,
            Description = entity.Description,
            Image = entity.Image,
            CreatedAt = entity.CreatedAt,
            CreatedBy = UserMapper.ToDomainBasic(entity.CreatedBy),
            LikedBy = entity.LikedBy.Select(UserMapper.ToDomain).ToList(),
            Products = entity.Products.Select(DishProductMapper.ToDomain).ToList()
        };

        public static DishEntity ToEntity(Dish domain)
        {
            var dishEntity = new DishEntity
            {
                Id = domain.Id,
                Title = domain.Title,
                Description = domain.Description,
                Image = domain.Image,
                CreatedAt = domain.CreatedAt,
                CreatedById = domain.CreatedBy.Id,
                LikedBy = domain.LikedBy.Select(UserMapper.ToEntity).ToList(),
                Products = domain.Products.Select(DishProductMapper.ToEntity).ToList()
            };

            return dishEntity;
        }
    }

}
