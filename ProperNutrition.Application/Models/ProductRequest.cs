using Microsoft.AspNetCore.Http;

namespace ProperNutrition.Application.Models
{
    public class ProductRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public double Calories { get; set; } = 0;

        public double Proteins { get; set; } = 0;

        public double Fats { get; set; } = 0;

        public double Carbs { get; set; } = 0;
    }
}
