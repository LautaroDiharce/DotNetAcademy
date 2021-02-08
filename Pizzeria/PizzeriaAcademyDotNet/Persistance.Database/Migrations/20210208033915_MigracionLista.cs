using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Database.Migrations
{
    public partial class MigracionLista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<int>(type: "int", nullable: false),
                    apellido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Estado",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ambito = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descipcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estado", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tamaño",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    porciones = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tamaño", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "TipoPizza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPizza", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Variedad",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Variedad", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    total = table.Column<int>(type: "int", nullable: false),
                    estadoid = table.Column<int>(type: "int", nullable: true),
                    clienteid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pedido_Cliente_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Cliente",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pedido_Estado_estadoid",
                        column: x => x.estadoid,
                        principalTable: "Estado",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descipcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variedadid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_Variedad_Variedadid",
                        column: x => x.Variedadid,
                        principalTable: "Variedad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pizza",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipoPizzaid = table.Column<int>(type: "int", nullable: true),
                    variedadid = table.Column<int>(type: "int", nullable: true),
                    tamañoid = table.Column<int>(type: "int", nullable: true),
                    precio = table.Column<int>(type: "int", nullable: false),
                    Menuid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza", x => x.id);
                    table.ForeignKey(
                        name: "FK_Pizza_Menu_Menuid",
                        column: x => x.Menuid,
                        principalTable: "Menu",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_Tamaño_tamañoid",
                        column: x => x.tamañoid,
                        principalTable: "Tamaño",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_TipoPizza_tipoPizzaid",
                        column: x => x.tipoPizzaid,
                        principalTable: "TipoPizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Pizza_Variedad_variedadid",
                        column: x => x.variedadid,
                        principalTable: "Variedad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Factura",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pedidoid = table.Column<int>(type: "int", nullable: true),
                    monto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factura", x => x.id);
                    table.ForeignKey(
                        name: "FK_Factura_Pedido_pedidoid",
                        column: x => x.pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Detalle",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pizzaid = table.Column<int>(type: "int", nullable: true),
                    montoUnitario = table.Column<int>(type: "int", nullable: false),
                    Pedidoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalle", x => x.id);
                    table.ForeignKey(
                        name: "FK_Detalle_Pedido_Pedidoid",
                        column: x => x.Pedidoid,
                        principalTable: "Pedido",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Detalle_Pizza_pizzaid",
                        column: x => x.pizzaid,
                        principalTable: "Pizza",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_Pedidoid",
                table: "Detalle",
                column: "Pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Detalle_pizzaid",
                table: "Detalle",
                column: "pizzaid");

            migrationBuilder.CreateIndex(
                name: "IX_Factura_pedidoid",
                table: "Factura",
                column: "pedidoid");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_Variedadid",
                table: "Ingrediente",
                column: "Variedadid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_clienteid",
                table: "Pedido",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_estadoid",
                table: "Pedido",
                column: "estadoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_Menuid",
                table: "Pizza",
                column: "Menuid");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_tamañoid",
                table: "Pizza",
                column: "tamañoid");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_tipoPizzaid",
                table: "Pizza",
                column: "tipoPizzaid");

            migrationBuilder.CreateIndex(
                name: "IX_Pizza_variedadid",
                table: "Pizza",
                column: "variedadid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Detalle");

            migrationBuilder.DropTable(
                name: "Factura");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "Pizza");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Tamaño");

            migrationBuilder.DropTable(
                name: "TipoPizza");

            migrationBuilder.DropTable(
                name: "Variedad");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estado");
        }
    }
}
