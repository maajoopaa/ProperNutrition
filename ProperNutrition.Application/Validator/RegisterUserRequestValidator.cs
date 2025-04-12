using FluentValidation;
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Validator
{
    public class RegisterUserRequestValidator : AbstractValidator<RegisterUserRequest>
    {
        public RegisterUserRequestValidator()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(6).WithMessage("Логин не может быть меньше 6 символов!");
            RuleFor(x => x.Email).NotEmpty().MinimumLength(10).WithMessage("Почта не может быть меньше 10 символов");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(6).WithMessage("Пароль не может быть меньше 6 символов");
        }
    }
}
