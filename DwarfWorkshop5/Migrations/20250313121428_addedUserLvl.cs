using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwarfWorkshop5.Migrations
{
    /// <inheritdoc />
    public partial class addedUserLvl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Lvl",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lvl",
                table: "User");
        }
    }
}
