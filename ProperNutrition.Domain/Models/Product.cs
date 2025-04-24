using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public string Image { get; set; } = null!;

        public double Calories { get; set; } = 0;

        public double Proteins { get; set; } = 0;

        public double Fats { get; set; } = 0;

        public double Carbs { get; set; } = 0;
    }
}
