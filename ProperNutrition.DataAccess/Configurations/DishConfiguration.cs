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
    public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
    {
        public void Configure(EntityTypeBuilder<DishEntity> builder)
        {
            builder.HasKey(d => d.Id);

            //max length change
            builder.Property(d => d.Title)
                .HasMaxLength(23)
                .IsRequired();

            //max length change
            builder.Property(d => d.Description)
                .HasMaxLength(23)
                .IsRequired();

            builder.Property(d => d.Image)
                .IsRequired();
        }
    }
}
