using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CookbookDataAccess.Migrations
{
    /// <inheritdoc />
    public partial class DBRework : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Guide_GuideId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "CaloryTab");

            migrationBuilder.DropTable(
                name: "Guide");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_GuideId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "TabId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "GuideId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "Measurement",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "LastCooced",
                table: "Recipes",
                newName: "LastCooked");

            migrationBuilder.AlterColumn<int>(
                name: "Volume",
                table: "Ingredients",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "Name");

            migrationBuilder.CreateTable(
                name: "Guides",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WritenGuide = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TotalCalories = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    TotalProtein = table.Column<float>(type: "real", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "IngredientTabs",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Measurement = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    Kcal = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Protein = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    GuidesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientTabs", x => x.Name);
                    table.ForeignKey(
                        name: "FK_IngredientTabs_Guides_GuidesId",
                        column: x => x.GuidesId,
                        principalTable: "Guides",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientTabs_GuidesId",
                table: "IngredientTabs",
                column: "GuidesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientTabs");

            migrationBuilder.DropTable(
                name: "Guides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients");

            migrationBuilder.RenameColumn(
                name: "LastCooked",
                table: "Recipes",
                newName: "LastCooced");

            migrationBuilder.AlterColumn<float>(
                name: "Volume",
                table: "Ingredients",
                type: "real",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "TabId",
                table: "Ingredients",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "GuideId",
                table: "Ingredients",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Measurement",
                table: "Ingredients",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ingredients",
                table: "Ingredients",
                column: "TabId");

            migrationBuilder.CreateTable(
                name: "CaloryTab",
                columns: table => new
                {
                    TabId = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kcal = table.Column<int>(type: "int", maxLength: 50, nullable: false),
                    Protein = table.Column<float>(type: "real", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaloryTab", x => x.TabId);
                });

            migrationBuilder.CreateTable(
                name: "Guide",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", maxLength: 50, nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalCalories = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    TotalProtein = table.Column<float>(type: "real", maxLength: 50, nullable: false),
                    WritenGuide = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guide", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_GuideId",
                table: "Ingredients",
                column: "GuideId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Guide_GuideId",
                table: "Ingredients",
                column: "GuideId",
                principalTable: "Guide",
                principalColumn: "Id");
        }
    }
}
