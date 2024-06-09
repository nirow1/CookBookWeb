using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class modelsReworked : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "IngredientId",
                table: "IngredientTabs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GuidesIngredients",
                columns: table => new
                {
                    GuidesId = table.Column<int>(type: "int", nullable: false),
                    IngredientsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GuidesIngredients", x => new { x.GuidesId, x.IngredientsId });
                    table.ForeignKey(
                        name: "FK_GuidesIngredients_Guides_GuidesId",
                        column: x => x.GuidesId,
                        principalTable: "Guides",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GuidesIngredients_Ingredients_IngredientsId",
                        column: x => x.IngredientsId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTabs_IngredientId",
                table: "IngredientTabs",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guides_RecipeId",
                table: "Guides",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_GuidesIngredients_IngredientsId",
                table: "GuidesIngredients",
                column: "IngredientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Guides_Recipes_RecipeId",
                table: "Guides",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_IngredientTabs_Ingredients_IngredientId",
                table: "IngredientTabs",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Guides_Recipes_RecipeId",
                table: "Guides");

            migrationBuilder.DropForeignKey(
                name: "FK_IngredientTabs_Ingredients_IngredientId",
                table: "IngredientTabs");

            migrationBuilder.DropTable(
                name: "GuidesIngredients");

            migrationBuilder.DropIndex(
                name: "IX_IngredientTabs_IngredientId",
                table: "IngredientTabs");

            migrationBuilder.DropIndex(
                name: "IX_Guides_RecipeId",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "IngredientId",
                table: "IngredientTabs");

            migrationBuilder.AddColumn<int>(
                name: "GuidesId",
                table: "Ingredients",
                type: "int",
                nullable: true);

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
    }
}
