using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class Dish
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public byte[] Image { get; set; } = null!;

        public DateTime CreatedAt { get; set; }

        public User CreatedBy { get; set; } = null!;

        public List<User> LikedBy { get; set; } = [];

        public List<DishProduct> Products { get; set; } = [];
    }
}
