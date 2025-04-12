
namespace ProperNutrition.Application.Services.AccountService
{
    public interface IAccountService
    {
        Task<string> Login(string username, string password);
        Task<string> Register(string username, string email, string password);
    }
}