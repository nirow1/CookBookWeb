using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class resipe_repare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "calories",
                table: "Recipes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "calories",
                table: "Recipes",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);
        }
    }
}
