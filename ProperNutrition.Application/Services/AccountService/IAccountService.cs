
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Services.AccountService
{
    public interface IAccountService
    {
        Task<AccountResponse?> Login(string username, string password);
        Task<AccountResponse?> Register(string username, string email, string password);
    }
}