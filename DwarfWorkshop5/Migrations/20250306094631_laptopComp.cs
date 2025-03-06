using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DwarfWorkshop5.Migrations
{
    /// <inheritdoc />
    public partial class laptopComp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaterialRequirement_Products_MaterialId",
                table: "MaterialRequirement");

            migrationBuilder.DropForeignKey(
                name: "FK_Recipes_Products_ProductId1",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_Recipes_ProductId1",
                table: "Recipes");

            migrationBuilder.DropIndex(
                name: "IX_MaterialRequirement_MaterialId",
                table: "MaterialRequirement");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "IsBar",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsMaterial",
                table: "Products");

            migrationBuilder.AlterColumn<double>(
                name: "TimeEfficiency",
                table: "Products",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "MaterialRequirement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "MaterialRequirement");

            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "Recipes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "TimeEfficiency",
                table: "Products",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "RecipeId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBar",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsMaterial",
                table: "Products",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProductId1",
                table: "Recipes",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialRequirement_MaterialId",
                table: "MaterialRequirement",
                column: "MaterialId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaterialRequirement_Products_MaterialId",
                table: "MaterialRequirement",
                column: "MaterialId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recipes_Products_ProductId1",
                table: "Recipes",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
