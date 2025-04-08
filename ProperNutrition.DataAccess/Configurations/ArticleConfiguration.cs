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
    public class ArticleConfiguration : IEntityTypeConfiguration<ArticleEntity>
    {
        public void Configure(EntityTypeBuilder<ArticleEntity> builder)
        {
            builder.HasKey(a => a.Id);

            //max length change
            builder.Property(a => a.Head)
                .HasMaxLength(23)
                .IsRequired();

            //max length change
            builder.Property(a => a.Body)
                .HasMaxLength(23)
                .IsRequired();
        }
    }
}
