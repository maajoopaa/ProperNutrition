using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Configurations
{
    public class DishConfiguration : IEntityTypeConfiguration<DishEntity>
    {
        public void Configure(EntityTypeBuilder<DishEntity> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Title)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(d => d.Description)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(d => d.Image)
                .IsRequired();
        }
    }
}
