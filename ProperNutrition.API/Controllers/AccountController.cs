using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services.AccountService;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<LoginUserRequest> _loginValidator;
        private readonly IValidator<RegisterUserRequest> _regValidator;

        public AccountController(IAccountService accountService, 
            IValidator<LoginUserRequest> loginValidator, IValidator<RegisterUserRequest> regValidator)
        {
            _accountService = accountService;
            _loginValidator = loginValidator;
            _regValidator = regValidator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest model)
        {
            try
            {
                _loginValidator.ValidateAndThrow(model);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var result = await _accountService.Login(model.Username,model.Password);

            return !string.IsNullOrEmpty(result) ? Ok(result) : BadRequest("Перепроверьте введенные данные.");
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserRequest model)
        {
            try
            {
                _regValidator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var result = await _accountService.Register(model.Username, model.Email, model.Password);

            return !string.IsNullOrEmpty(result) ? Ok(result) : BadRequest("Пользователь с таким логином или почтой уже существует!");
        }
    }
}
