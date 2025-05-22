using FluentValidation;
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Validator
{
    public class ArticleRequestValidator : AbstractValidator<ArticleRequest>
    {
        public ArticleRequestValidator()
        {
            RuleFor(x => x.Head).NotEmpty().MaximumLength(100).WithMessage("Название не может быть пустым или больше 100 символов");
            RuleFor(x => x.Body).NotEmpty().MaximumLength(1000).WithMessage("Тело не может быть пустым или больше 1000 символов");
        }
    }
}