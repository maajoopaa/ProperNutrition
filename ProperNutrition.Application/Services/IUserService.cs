using Microsoft.AspNetCore.Http;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IUserService
    {
        Task<User?> AddAsync(string username, string email, string password);
        Task<List<Dish>> GetDishes(HttpContext context);
        Task<List<Dish>> GetFavouriteAsync(HttpContext context);
        Task<UserEntity?> GetByUsername(string username);
    }
}