using ProperNutrition.Domain.Entities;
using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Mappers
{
    public class ArticleMapper
    {
        public static Article ToDomain(ArticleEntity entity) => new Article
        {
            Id = entity.Id,
            Head = entity.Head,
            Body = entity.Body,
            Image = entity.Image,
            CreatedAt = entity.CreatedAt,
        };

        public static ArticleEntity ToEntity(Article domain) => new ArticleEntity
        {
            Id = domain.Id,
            Head = domain.Head,
            Body = domain.Body,
            Image = domain.Image,
            CreatedAt = domain.CreatedAt,
        };
    }
}
