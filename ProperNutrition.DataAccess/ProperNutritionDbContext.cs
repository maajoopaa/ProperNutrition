﻿using Microsoft.EntityFrameworkCore;
using ProperNutrition.DataAccess.Configurations;
using ProperNutrition.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProperNutrition.DataAccess
{
    public class ProperNutritionDbContext : DbContext
    {
        public ProperNutritionDbContext(DbContextOptions<ProperNutritionDbContext> options)
            :base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<ArticleEntity> Articles { get; set; }
        public DbSet<DishEntity> Dishes { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<DishProductEntity> DishProducts { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new DishProductConfiguration());
            modelBuilder.ApplyConfiguration(new DishConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
