using FluentValidation;
using ProperNutrition.Application.Models;

namespace ProperNutrition.Application.Validator
{
    public class ProductRequestValidator : AbstractValidator<ProductRequest>
    {
        public ProductRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(30).WithMessage("Название не может быть пустым или более 30 символов");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(150).WithMessage("Описание не может быть пустым или более 150 символов");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Изображение не может быть пустым!");
            RuleFor(x => x.Calories).GreaterThanOrEqualTo(0).WithMessage("Количество калорий не может быть меньше 0");
            RuleFor(x => x.Proteins).GreaterThanOrEqualTo(0).WithMessage("Количество белков не может быть меньше 0");
            RuleFor(x => x.Fats).GreaterThanOrEqualTo(0).WithMessage("Количество жиров не может быть меньше 0");
            RuleFor(x => x.Carbs).GreaterThanOrEqualTo(0).WithMessage("Количество углеводов не может быть меньше 0");
        }
    }
}
