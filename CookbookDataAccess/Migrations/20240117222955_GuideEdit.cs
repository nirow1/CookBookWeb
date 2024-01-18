using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class GuideEdit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipeId",
                table: "Guides",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Score",
                table: "Guides",
                type: "real",
                maxLength: 50,
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Guides",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RecipeId",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Guides");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Guides");
        }
    }
}
