using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Models;

namespace ProperNutrition.Application.Services
{
    public interface IDishService
    {
        Task<string> AddAsync(Guid createdBydId, DishRequest model);
        Task<(double Calories, double Proteins, double Fats, double Carbs)> CalculateCPFC(Guid id);
        Task<string> DeleteAsync(Guid id);
        Task<List<Dish>> GetAllAsync();
        Task<Dish?> GetAsync(Guid id);
        Task<List<Dish>> GetLessCaloritAsync();
        Task<List<Dish>> SearchAsync(string query);
        Task<string> UpdateAsync(Guid id, DishRequest model);
    }
}