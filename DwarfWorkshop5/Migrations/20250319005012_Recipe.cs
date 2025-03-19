using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwarfWorkshop5.Migrations
{
    /// <inheritdoc />
    public partial class Recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeChoices",
                table: "Dwarfs");

            migrationBuilder.AddColumn<int>(
                name: "SelectedRecipe1",
                table: "Dwarfs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedRecipe2",
                table: "Dwarfs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SelectedRecipe3",
                table: "Dwarfs",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SelectedRecipe1",
                table: "Dwarfs");

            migrationBuilder.DropColumn(
                name: "SelectedRecipe2",
                table: "Dwarfs");

            migrationBuilder.DropColumn(
                name: "SelectedRecipe3",
                table: "Dwarfs");

            migrationBuilder.AddColumn<string>(
                name: "RecipeChoices",
                table: "Dwarfs",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
