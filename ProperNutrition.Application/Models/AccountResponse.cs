using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Models
{
    public class AccountResponse
    {
        public string? Token { get; set; }

        public User? User { get; set; }
    }
}
