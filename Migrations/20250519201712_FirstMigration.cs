using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cokhot.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IdIngredient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomIngredient = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrixKiloIngredient = table.Column<decimal>(type: "decimal(65,30)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IdIngredient);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Plats",
                columns: table => new
                {
                    IdPlat = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomPlat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    saveurPlat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    estEpicePlat = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    estHealthy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    estVegetarien = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    originePlat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    tempsPreparationPlat = table.Column<int>(type: "int", nullable: true),
                    repasPlat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lienRecettePlat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lienPhotoPlat = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    notePlat = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plats", x => x.IdPlat);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "IngredientsDansPlat",
                columns: table => new
                {
                    IdPlat = table.Column<int>(type: "int", nullable: false),
                    IdIngredient = table.Column<int>(type: "int", nullable: false),
                    PlatIdPlat = table.Column<int>(type: "int", nullable: false),
                    IngredientIdIngredient = table.Column<int>(type: "int", nullable: false),
                    QuantiteIngredient = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsDansPlat", x => new { x.IdPlat, x.IdIngredient });
                    table.ForeignKey(
                        name: "FK_IngredientsDansPlat_Ingredients_IngredientIdIngredient",
                        column: x => x.IngredientIdIngredient,
                        principalTable: "Ingredients",
                        principalColumn: "IdIngredient",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsDansPlat_Plats_PlatIdPlat",
                        column: x => x.PlatIdPlat,
                        principalTable: "Plats",
                        principalColumn: "IdPlat",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Plats",
                columns: new[] { "IdPlat", "estEpicePlat", "estHealthy", "estVegetarien", "lienPhotoPlat", "lienRecettePlat", "nomPlat", "notePlat", "originePlat", "repasPlat", "saveurPlat", "tempsPreparationPlat" },
                values: new object[,]
                {
                    { 1, false, true, false, "", "", "Spaghetti Bolognese", 5, "Italie", "Dîner", "Savoureux", 30 },
                    { 2, false, true, false, "", "", "Salade César", 4, "États-Unis", "Déjeuner", "Frais", 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsDansPlat_IngredientIdIngredient",
                table: "IngredientsDansPlat",
                column: "IngredientIdIngredient");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsDansPlat_PlatIdPlat",
                table: "IngredientsDansPlat",
                column: "PlatIdPlat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsDansPlat");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Plats");
        }
    }
}
