using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        public byte IsAdmin { get; set; } = 0;

        public virtual ICollection<DishEntity> Dishes { get; set; } = [];

        public virtual ICollection<DishEntity> Favourite { get; set; } = [];

        public bool IsConfirmed { get; set; } = false;

        public bool? Gender { get; set; }

        public double? Weight { get; set; }

        public double? Height { get; set; }
    }
}
