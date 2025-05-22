using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProperNutrition.Application.Models;
using ProperNutrition.Application.Services;
using ProperNutrition.Application.Services.AccountService;

namespace ProperNutrition.API.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly IValidator<LoginUserRequest> _loginValidator;
        private readonly IValidator<RegisterUserRequest> _regValidator;
        private readonly IUserService _userService;
        private readonly IValidator<ParametrsRequest> _paramValidator;

        public AccountController(IAccountService accountService, 
            IValidator<LoginUserRequest> loginValidator, IValidator<RegisterUserRequest> regValidator, IUserService userService,
            IValidator<ParametrsRequest> paramValidator)
        {
            _accountService = accountService;
            _loginValidator = loginValidator;
            _regValidator = regValidator;
            _userService = userService;
            _paramValidator = paramValidator;
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

            return result is not null ? Ok(result) : BadRequest("Перепроверьте введенные данные.");
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

            return result is not null ? Ok(result) : BadRequest("Пользователь с таким логином или почтой уже существует!");
        }

        [Authorize]
        [HttpPost("{id:guid}")]
        public async Task<IActionResult> ChangeData(Guid id, [FromBody] UserRequest model)
        {
            var result = await _userService.UpdateAsync(id, model);

            return string.IsNullOrEmpty(result) ? Ok() : BadRequest(result);
        }

        [HttpGet("")]
        public async Task<IActionResult> Account()
        {
            var id = GetUserId();

            var result = await _userService.GetById(id);

            return result is not null ? Ok(result) : BadRequest("Пользователь не найден!");
        }

        [HttpPatch("{id:guid}/parametrs"),Authorize]
        public async Task<IActionResult> UpdateParamerts(Guid id,[FromBody] ParametrsRequest model)
        {
            try
            {
                _paramValidator.ValidateAndThrow(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            var response = await _userService.UpdateParametrsAsync(id, model);

            return response is not null ? Ok(response) : BadRequest("Пользователь не найден!");
        }

        private Guid GetUserId()
        {
            Guid.TryParse(User.FindFirst("userId")?.Value ?? string.Empty, out Guid id);

            return id;
        }
    }
}
