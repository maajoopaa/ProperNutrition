using Npgsql.Internal;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Application.Mappers;
using System.ComponentModel.DataAnnotations;

namespace ProperNutrition.Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<string> Register(string username, string email, string password)
        {
            string passwordHash = PasswordHasher.Hash(password);

            var user = await _userService.AddAsync(username, email, passwordHash);

            if(user is not null)
            {
                var token = await Login(username, password);

                return token;
            }

            return string.Empty;
        }

        public async Task<string> Login(string username, string password)
        {
            var user = await _userService.GetByUsername(username);

            if (user is not null && PasswordHasher.Verify(password,user.Password))
            {
                return JwtService.GenerateToken(UserMapper.ToDomain(user));
            }

            return string.Empty;
        }
    }
}
