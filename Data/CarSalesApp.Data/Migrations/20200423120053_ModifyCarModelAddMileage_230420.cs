using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSalesApp.Data.Migrations
{
    public partial class ModifyCarModelAddMileage_230420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mileage",
                table: "Cars",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");
        }
    }
}
