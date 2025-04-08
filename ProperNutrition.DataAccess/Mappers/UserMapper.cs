using ProperNutrition.DataAccess.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Mappers
{
    public static class UserMapper
    {
        public static User ToDomain(UserEntity entity) => new User
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            IsAdmin = entity.IsAdmin != 0,
            CreatedDishes = entity.Dishes?.Select(DishMapper.ToDomain).ToList() ?? new(),
            FavouriteDishes = entity.Favourite?.Select(DishMapper.ToDomain).ToList() ?? new()
        };

        public static User ToDomainBasic(UserEntity entity) => new User
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            IsAdmin = entity.IsAdmin != 0
        };

        public static UserEntity ToEntity(User domain) => new UserEntity
        {
            Id = domain.Id,
            Username = domain.Username,
            Email = domain.Email,
            IsAdmin = domain.IsAdmin ? (byte)1 : (byte)0
        };
    }

}
