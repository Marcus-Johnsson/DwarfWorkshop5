using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwarfWorkshop5.Migrations
{
    /// <inheritdoc />
    public partial class NewDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Products_ProductsId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductsId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "WorkOrder",
                table: "Dwarfs",
                newName: "RecipeChoices");

            migrationBuilder.AlterColumn<string>(
                name: "DwarfId",
                table: "WorkOrder",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "WorkOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Quality",
                table: "Inventory",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "WorkOrder");

            migrationBuilder.DropColumn(
                name: "Quality",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Inventory");

            migrationBuilder.RenameColumn(
                name: "RecipeChoices",
                table: "Dwarfs",
                newName: "WorkOrder");

            migrationBuilder.AlterColumn<int>(
                name: "DwarfId",
                table: "WorkOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductsId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsId",
                table: "Products",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Products_ProductsId",
                table: "Products",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
