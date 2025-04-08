using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Npgsql.Internal;
using ProperNutrition.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Configurations
{
    public class DishProductConfiguration : IEntityTypeConfiguration<DishProductEntity>
    {
        public void Configure(EntityTypeBuilder<DishProductEntity> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.DishId });

            builder.HasOne(x => x.Product)
                .WithMany(p => p.Dishes)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Dish)
                .WithMany(d => d.Products)
                .HasForeignKey(x => x.DishId);
        }
    }
}
