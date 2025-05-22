using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Models
{
    public class ParametrsRequest
    {
        public bool IsConfirmed { get; set; } = false;

        public bool Gender { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }
    }
}
