using Npgsql.Internal;
using ProperNutrition.DataAccess.Repositories;
using ProperNutrition.Domain.Entities;
using ProperNutrition.Application.Mappers;
using System.ComponentModel.DataAnnotations;
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IUserService _userService;

        public AccountService(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<AccountResponse?> Register(string username, string email, string password)
        {
            string passwordHash = PasswordHasher.Hash(password);

            var user = await _userService.AddAsync(username, email, passwordHash);

            if(user is not null)
            {
                return await Login(username, password);
            }

            return null;
        }

        public async Task<AccountResponse?> Login(string username, string password)
        {
            var user = await _userService.GetByUsername(username);

            if (user is not null && PasswordHasher.Verify(password,user.Password))
            {
                var token = JwtService.GenerateToken(UserMapper.ToDomain(user));

                return new AccountResponse{ Token = token, User = UserMapper.ToDomain(user) };
            }

            return null;
        }
    }
}
