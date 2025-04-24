using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProperNutrition.API.Migrations
{
    /// <inheritdoc />
    public partial class DishProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishProducts",
                table: "DishProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "DishProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishProducts",
                table: "DishProducts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DishProducts_ProductId",
                table: "DishProducts",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_DishProducts",
                table: "DishProducts");

            migrationBuilder.DropIndex(
                name: "IX_DishProducts_ProductId",
                table: "DishProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DishProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DishProducts",
                table: "DishProducts",
                columns: new[] { "ProductId", "DishId" });
        }
    }
}
