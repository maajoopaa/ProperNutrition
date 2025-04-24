using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.Domain.Models
{
    public class Article
    {
        public Guid Id { get; set; }

        public string Head { get; set; } = null!;

        public string Body { get; set; } = null!;

        public string? Image { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
