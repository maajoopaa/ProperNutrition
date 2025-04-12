using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public bool IsAdmin { get; set; } = false;

        public List<Dish> CreatedDishes { get; set; } = new();

        public List<Dish> FavouriteDishes { get; set; } = new();
    }
}
