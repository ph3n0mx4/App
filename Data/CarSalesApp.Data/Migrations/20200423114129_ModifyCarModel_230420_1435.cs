using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSalesApp.Data.Migrations
{
    public partial class ModifyCarModel_230420_1435 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneralImg",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MainImage",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MainImage",
                table: "Cars");

            migrationBuilder.AddColumn<string>(
                name: "GeneralImg",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
