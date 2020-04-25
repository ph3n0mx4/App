using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSalesApp.Data.Migrations
{
    public partial class ModifyCarsFeaturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "CarsFeatures",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CarsFeatures",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CarsFeatures",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "CarsFeatures",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarsFeatures_IsDeleted",
                table: "CarsFeatures",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CarsFeatures_IsDeleted",
                table: "CarsFeatures");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "CarsFeatures");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CarsFeatures");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CarsFeatures");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "CarsFeatures");
        }
    }
}
