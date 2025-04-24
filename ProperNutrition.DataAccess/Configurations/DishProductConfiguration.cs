using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Configurations
{
    public class DishProductConfiguration : IEntityTypeConfiguration<DishProductEntity>
    {
        public void Configure(EntityTypeBuilder<DishProductEntity> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(p => p.Dishes)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Dish)
                .WithMany(d => d.Products)
                .HasForeignKey(x => x.DishId);
        }
    }
}
