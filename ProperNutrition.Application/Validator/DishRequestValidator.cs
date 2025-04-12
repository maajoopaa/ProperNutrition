using FluentValidation;
using ProperNutrition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Validator
{
    public class DishRequestValidator : AbstractValidator<DishRequest>
    {
        public DishRequestValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(30).WithMessage("Название блюда не может быть пустым или больше 30 символов");
            RuleFor(x => x.Description).NotEmpty().MaximumLength(150).WithMessage("Описание блюда не может быть пустым или больше 150 символов");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Изображение не может быть пустым!");
            RuleForEach(x => x.Products)
                .SetValidator(new DishProductRequestValidator());
        }
    }
}
