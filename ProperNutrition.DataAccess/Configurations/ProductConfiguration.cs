using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(p => p.Description)
                .HasMaxLength(150)
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
