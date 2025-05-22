using Microsoft.AspNetCore.Http;
using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IUserService
    {
        Task<User?> AddAsync(string username, string email, string password);
        Task<User?> GetById(Guid id);
        Task<UserEntity?> GetByUsername(string username);
        Task<List<Dish>> GetDishes(HttpContext context);
        Task<List<Dish>> GetFavouriteAsync(HttpContext context);
        Task<string> UpdateAsync(Guid id, UserRequest model);
        Task<string> UpdateParametrsAsync(Guid id, ParametrsRequest model);
    }
}