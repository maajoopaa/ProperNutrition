using FluentValidation;
using ProperNutrition.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Validator
{
    public class ArticleRequestValidator : AbstractValidator<ArticleRequest>
    {
        public ArticleRequestValidator()
        {
            RuleFor(x => x.Head).NotEmpty().MaximumLength(30).WithMessage("Название не может быть пустым или больше 30 символов");
            RuleFor(x => x.Body).NotEmpty().MaximumLength(150).WithMessage("Тело не может быть пустым или больше 150 символов");
        }
    }
}
