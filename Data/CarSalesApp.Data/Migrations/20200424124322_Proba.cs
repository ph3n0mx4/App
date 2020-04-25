using Microsoft.EntityFrameworkCore.Migrations;

namespace CarSalesApp.Data.Migrations
{
    public partial class Proba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureTypes_TypeId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_TypeId",
                table: "Features");

            migrationBuilder.AddColumn<int>(
                name: "FeatureTypeId",
                table: "Features",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Features_FeatureTypeId",
                table: "Features",
                column: "FeatureTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureTypes_FeatureTypeId",
                table: "Features",
                column: "FeatureTypeId",
                principalTable: "FeatureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_FeatureTypes_FeatureTypeId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Features_FeatureTypeId",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "FeatureTypeId",
                table: "Features");

            migrationBuilder.CreateIndex(
                name: "IX_Features_TypeId",
                table: "Features",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_FeatureTypes_TypeId",
                table: "Features",
                column: "TypeId",
                principalTable: "FeatureTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
