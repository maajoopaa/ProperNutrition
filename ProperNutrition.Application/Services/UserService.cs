using Microsoft.AspNetCore.Http;
using ProperNutrition.Application.Mappers;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<User?> GetById(Guid id)
        {
            var users = await _usersRepository.GetAllAsync();

            var user = users.FirstOrDefault(u => u.Id == id);

            return user is not null ? UserMapper.ToDomain(user) : null;
        }

        public async Task<User?> AddAsync(string username, string email, string password)
        {
            try
            {
                var entity = new UserEntity
                {
                    Username = username,
                    Email = email,
                    Password = password
                };

                await _usersRepository.AddAsync(entity);

                return UserMapper.ToDomain(entity);
            }
            catch
            {
                return null;
            }
        }

        public async Task<UserEntity?> GetByUsername(string username)
        {
            return (await _usersRepository.GetAllAsync())
                .FirstOrDefault(u => u.Username == username);
        }

        public async Task<List<Dish>> GetFavouriteAsync(HttpContext context)
        {
            var userId = Guid.Parse(context.User?.Claims?
                .FirstOrDefault(c => c.Type == "userId")?.Value!);

            var userEntity = await _usersRepository.GetAsync(userId);

            if (userEntity is not null)
            {
                var favouriteEntities = userEntity.Favourite;

                return favouriteEntities.Select(DishMapper.ToDomain)
                    .ToList();
            }

            return [];
        }

        public async Task<List<Dish>> GetDishes(HttpContext context)
        {
            var userId = Guid.Parse(context.User?.Claims?
                .FirstOrDefault(c => c.Type == "userId")?.Value!);

            var userEntity = await _usersRepository.GetAsync(userId);

            if (userEntity is not null)
            {
                var dishEntities = userEntity.Dishes;

                return dishEntities.Select(DishMapper.ToDomain)
                    .ToList();
            }

            return [];
        }
    }
}
