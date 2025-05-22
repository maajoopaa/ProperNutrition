using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Mappers
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
            FavouriteDishes = entity.Favourite?.Select(DishMapper.ToDomain).ToList() ?? new(),
            IsConfirmed = entity.IsConfirmed,
            Gender= entity.Gender,
            Weight= entity.Weight,
            Height= entity.Height,
        };

        public static User ToDomainBasic(UserEntity entity) => new User
        {
            Id = entity.Id,
            Username = entity.Username,
            Email = entity.Email,
            IsAdmin = entity.IsAdmin != 0,
            IsConfirmed = entity.IsConfirmed,
            Gender = entity.Gender,
            Weight = entity.Weight,
            Height = entity.Height,
        };

        public static UserEntity ToEntity(User domain) => new UserEntity
        {
            Id = domain.Id,
            Username = domain.Username,
            Email = domain.Email,
            IsAdmin = domain.IsAdmin ? (byte)1 : (byte)0,
            IsConfirmed = domain.IsConfirmed,
            Gender = domain.Gender,
            Weight = domain.Weight,
            Height = domain.Height,
        };
    }

}
