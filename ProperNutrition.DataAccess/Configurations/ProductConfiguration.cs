using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            //max length change
            builder.Property(p => p.Title)
                .HasMaxLength(23)
                .IsRequired();

            //max length change
            builder.Property(p => p.Description)
                .HasMaxLength(23)
                .IsRequired();

            builder.Property(p => p.Image)
                .IsRequired();

            builder.Property(p => p.Calories)
                .IsRequired();

            builder.Property(p => p.Proteins)
                .IsRequired();

            builder.Property(p => p.Fats)
                .IsRequired();

            builder.Property(p => p.Carbs)
                .IsRequired();
        }
    }
}
