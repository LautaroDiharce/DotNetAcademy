using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Database.Migrations
{
    public partial class deleteListaEnIngredientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientePizza");

            migrationBuilder.AddColumn<int>(
                name: "Pizzaid",
                table: "Ingrediente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_Pizzaid",
                table: "Ingrediente",
                column: "Pizzaid");

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Pizza_Pizzaid",
                table: "Ingrediente",
                column: "Pizzaid",
                principalTable: "Pizza",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Pizza_Pizzaid",
                table: "Ingrediente");

            migrationBuilder.DropIndex(
                name: "IX_Ingrediente_Pizzaid",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "Pizzaid",
                table: "Ingrediente");

            migrationBuilder.CreateTable(
                name: "IngredientePizza",
                columns: table => new
                {
                    ingredientesid = table.Column<int>(type: "int", nullable: false),
                    pizzasid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientePizza", x => new { x.ingredientesid, x.pizzasid });
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Ingrediente_ingredientesid",
                        column: x => x.ingredientesid,
                        principalTable: "Ingrediente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientePizza_Pizza_pizzasid",
                        column: x => x.pizzasid,
                        principalTable: "Pizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientePizza_pizzasid",
                table: "IngredientePizza",
                column: "pizzasid");
        }
    }
}
