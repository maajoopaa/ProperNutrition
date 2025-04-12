using FluentValidation;
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Validator
{
    public class LoginUserRequestValidator : AbstractValidator<LoginUserRequest>
    {
        public LoginUserRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Введите логин!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Введите пароль!");
        }
    }
}
