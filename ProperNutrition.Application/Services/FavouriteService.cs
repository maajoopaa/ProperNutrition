﻿using ProperNutrition.Application.Mappers;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class FavouriteService : IFavouriteService
    {
        private readonly IDishesRepository _dishesRepository;
        private readonly IUsersRepository _usersRepository;

        public FavouriteService(IDishesRepository dishesRepository, IUsersRepository usersRepository)
        {
            _dishesRepository = dishesRepository;
            _usersRepository = usersRepository;
        }

        public async Task<string> LikeAsync(Guid userId, Guid dishId)
        {
            try
            {
                var dish = await _dishesRepository.GetAsync(dishId);
                var user = await _usersRepository.GetAsync(userId);

                if (user is not null)
                {
                    if (dish is not null)
                    {
                        if (user.Favourite.Contains(dish))
                        {
                            user.Favourite.Remove(dish);
                        }
                        else
                        { 
                            user.Favourite.Add(dish);
                        }

                        await _usersRepository.UpdateAsync(user);

                        return string.Empty;
                    }

                    return "Такого блюда не существует!";
                }

                return "Такого пользователя не существует!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Dish>> GetAllAsync(Guid userId)
        {
            try
            {
                var user = await _usersRepository.GetAsync(userId);

                if (user is not null)
                {
                    return user.Favourite.Select(DishMapper.ToDomain).ToList();
                }

                return [];
            }
            catch
            {
                return [];
            }
        }
    }
}
