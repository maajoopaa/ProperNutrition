using FluentValidation;
using ProperNutrition.Application.Models;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Validator
{
    public class DishProductRequestValidator : AbstractValidator<DishProductRequest>
    {
        public DishProductRequestValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Продукт не может быть пустым");
            RuleFor(x => x.Weight).GreaterThanOrEqualTo(0.001).WithMessage("Вес продукта не может быть меньше 1 грамма");
        }
    }
}
