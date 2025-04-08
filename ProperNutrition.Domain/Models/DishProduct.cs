using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class DishProduct
    {
        public Dish Dish { get; set; } = null!;

        public Product Product { get; set; } = null!;

        public double Weight { get; set; }
    }
}
