using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IngredienceRepare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTabs_Guides_GuidesId",
                table: "IngredientTabs");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTabs_GuidesId",
                table: "IngredientTabs");

            migrationBuilder.DropColumn(
                name: "GuidesId",
                table: "IngredientTabs");

            migrationBuilder.AddColumn<int>(
                name: "GuidesId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "TotalGrams",
                table: "Guides",
                type: "real",
                maxLength: 50,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_GuidesId",
                table: "Ingredients",
                column: "GuidesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Guides_GuidesId",
                table: "Ingredients",
                column: "GuidesId",
                principalTable: "Guides",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Guides_GuidesId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_GuidesId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "GuidesId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "TotalGrams",
                table: "Guides");

            migrationBuilder.AddColumn<int>(
                name: "GuidesId",
                table: "IngredientTabs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTabs_GuidesId",
                table: "IngredientTabs",
                column: "GuidesId");

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTabs_Guides_GuidesId",
                table: "IngredientTabs",
                column: "GuidesId",
                principalTable: "Guides",
                principalColumn: "Id");
        }
    }
}
