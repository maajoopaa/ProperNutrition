using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Entities
{
    public class DishProductEntity
    {
        public Guid DishId { get; set; }

        public virtual DishEntity Dish { get; set; } = null!;

        public Guid ProductId { get; set; }

        public virtual ProductEntity Product { get; set; } = null!;

        public double Weight { get; set; } = 0;
    }
}
