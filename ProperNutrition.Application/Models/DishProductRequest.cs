using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Models
{
    public class DishProductRequest
    {
        public Guid ProductId { get; set; }

        public double Weight { get; set; } = 0;
    }
}
