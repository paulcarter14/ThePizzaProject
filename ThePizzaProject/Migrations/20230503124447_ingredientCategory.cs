using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThePizzaProject.Migrations
{
    public partial class ingredientCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Ingredients");
        }
    }
}
