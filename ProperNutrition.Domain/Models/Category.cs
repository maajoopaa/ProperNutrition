using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public List<Dish> Dishes { get; set; } = [];
    }
}
