using Microsoft.EntityFrameworkCore.Migrations;

namespace Resturant.Data.Migrations
{
    public partial class Foods : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoLocation",
                table: "FoodModel",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoLocation",
                table: "FoodModel");
        }
    }
}
