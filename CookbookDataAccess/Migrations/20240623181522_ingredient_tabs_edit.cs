using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ingredient_tabs_edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTabs_Ingredients_IngredientId",
                table: "IngredientTabs");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTabs_IngredientId",
                table: "IngredientTabs");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientTabs");

            migrationBuilder.AddColumn<int>(
                name: "IngredientTabsId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IngredientTabsId",
                table: "Ingredients",
                column: "IngredientTabsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_IngredientTabs_IngredientTabsId",
                table: "Ingredients",
                column: "IngredientTabsId",
                principalTable: "IngredientTabs",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_IngredientTabs_IngredientTabsId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_IngredientTabsId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "IngredientTabsId",
                table: "Ingredients");

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "IngredientTabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTabs_IngredientId",
                table: "IngredientTabs",
                column: "IngredientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTabs_Ingredients_IngredientId",
                table: "IngredientTabs",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
