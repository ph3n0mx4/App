using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSalesApp.Data.Migrations
{
    public partial class ModifyCarModelModify_230420 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Cars");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mileage",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
