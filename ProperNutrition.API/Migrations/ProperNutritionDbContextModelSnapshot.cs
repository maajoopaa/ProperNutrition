﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProperNutrition.DataAccess;

#nullable disable

namespace ProperNutrition.API.Migrations
{
    [DbContext(typeof(ProperNutritionDbContext))]
    partial class ProperNutritionDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.4")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DishEntityUserEntity", b =>
                {
                    b.Property<Guid>("FavouriteId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("LikedById")
                        .HasColumnType("uuid");

                    b.HasKey("FavouriteId", "LikedById");

                    b.HasIndex("LikedById");

                    b.ToTable("DishEntityUserEntity");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.ArticleEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Head")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<byte[]>("Image")
                        .HasColumnType("bytea");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.DishEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CreatedById")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedById");

                    b.ToTable("Dishes");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.DishProductEntity", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("DishId")
                        .HasColumnType("uuid");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("ProductId", "DishId");

                    b.HasIndex("DishId");

                    b.ToTable("DishProducts");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Calories")
                        .HasColumnType("double precision");

                    b.Property<double>("Carbs")
                        .HasColumnType("double precision");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<double>("Fats")
                        .HasColumnType("double precision");

                    b.Property<byte[]>("Image")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<double>("Proteins")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<byte>("IsAdmin")
                        .HasColumnType("smallint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DishEntityUserEntity", b =>
                {
                    b.HasOne("ProperNutrition.Domain.Entities.DishEntity", null)
                        .WithMany()
                        .HasForeignKey("FavouriteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProperNutrition.Domain.Entities.UserEntity", null)
                        .WithMany()
                        .HasForeignKey("LikedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.DishEntity", b =>
                {
                    b.HasOne("ProperNutrition.Domain.Entities.UserEntity", "CreatedBy")
                        .WithMany("Dishes")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedBy");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.DishProductEntity", b =>
                {
                    b.HasOne("ProperNutrition.Domain.Entities.DishEntity", "Dish")
                        .WithMany("Products")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProperNutrition.Domain.Entities.ProductEntity", "Product")
                        .WithMany("Dishes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.DishEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.ProductEntity", b =>
                {
                    b.Navigation("Dishes");
                });

            modelBuilder.Entity("ProperNutrition.Domain.Entities.UserEntity", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
