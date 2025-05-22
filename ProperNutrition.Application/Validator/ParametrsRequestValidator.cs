using FluentValidation;
using ProperNutrition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Validator
{
    public class ParametrsRequestValidator : AbstractValidator<ParametrsRequest>
    {
        public ParametrsRequestValidator()
        {
            RuleFor(x => x.Height).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Рост не может быть равен 0");
            RuleFor(x => x.Weight).NotEmpty().GreaterThanOrEqualTo(1).WithMessage("Вес не может быть равен 0");
        }
    }
}
