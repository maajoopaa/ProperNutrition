using Microsoft.AspNetCore.Http;

namespace ProperNutrition.Application.Models
{
    public class ArticleRequest
    {
        public string Head { get; set; } = null!;

        public string Body { get; set; } = null!;

        public IFormFile? Image { get; set; }
    }
}
