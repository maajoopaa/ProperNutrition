using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProperNutrition.Domain.Entities;

namespace ProperNutrition.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Username)
                .IsRequired();

            builder.Property(u => u.Email)
                .IsRequired();

            builder.Property(u => u.Password)
                .IsRequired();

            builder.HasIndex(u => u.Username)
                .IsUnique();

            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.HasMany(u => u.Dishes)
                .WithOne(d => d.CreatedBy)
                .HasForeignKey(d => d.CreatedById);

            builder.HasMany(u => u.Favourite)
                .WithMany(d => d.LikedBy);
        }
    }
}
