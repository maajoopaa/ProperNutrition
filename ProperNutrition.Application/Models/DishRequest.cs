using Microsoft.AspNetCore.Http;
using ProperNutrition.Domain.Models;
using System.Runtime.InteropServices;

namespace ProperNutrition.Application.Models
{
    public class DishRequest
    {
        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public List<DishProductRequest> Products { get; set; } = [];

        public Guid CategoryId { get; set; }
    }
}
