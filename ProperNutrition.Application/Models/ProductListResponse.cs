using ProperNutrition.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Application.Models
{
    public class ProductListResponse
    {
        public List<Product> Products { get; set; } = [];

        public int Total { get; set; }
    }
}
