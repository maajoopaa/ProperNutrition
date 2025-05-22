using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Models
{
    public class DishListResponse
    {
        public List<Dish> Dishes { get; set; } = [];

        public int Total { get; set; }
    }
}
