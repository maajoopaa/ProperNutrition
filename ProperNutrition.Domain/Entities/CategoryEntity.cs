﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Entities
{
    public class CategoryEntity
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = null!;

        public virtual List<DishEntity> Dishes { get; set; } = [];
    }
}
