using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Database.Migrations
{
    public partial class Dbup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalle_Pedido_Pedidoid",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Variedad_Variedadid",
                table: "Ingrediente");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_clienteid",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Estado_estadoid",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Menu_Menuid",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Tamaño_tamañoid",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_TipoPizza_tipoPizzaid",
                table: "Pizza");

            migrationBuilder.DropForeignKey(
                name: "FK_Pizza_Variedad_variedadid",
                table: "Pizza");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Estado");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "Tamaño");

            migrationBuilder.DropTable(
                name: "TipoPizza");

            migrationBuilder.DropTable(
                name: "Variedad");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_Menuid",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_tamañoid",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_tipoPizzaid",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pizza_variedadid",
                table: "Pizza");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_clienteid",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_estadoid",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Menuid",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "tamañoid",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "tipoPizzaid",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "variedadid",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "clienteid",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "estadoid",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "monto",
                table: "Factura");

            migrationBuilder.RenameColumn(
                name: "descipcion",
                table: "Ingrediente",
                newName: "nombre");

            migrationBuilder.RenameColumn(
                name: "Variedadid",
                table: "Ingrediente",
                newName: "Pizzaid");

            migrationBuilder.RenameIndex(
                name: "IX_Ingrediente_Variedadid",
                table: "Ingrediente",
                newName: "IX_Ingrediente_Pizzaid");

            migrationBuilder.RenameColumn(
                name: "Pedidoid",
                table: "Detalle",
                newName: "pedidoid");

            migrationBuilder.RenameColumn(
                name: "montoUnitario",
                table: "Detalle",
                newName: "tamaño");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_Pedidoid",
                table: "Detalle",
                newName: "IX_Detalle_pedidoid");

            migrationBuilder.AddColumn<string>(
                name: "nombre",
                table: "Pizza",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cliente",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "demora",
                table: "Pedido",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "estado",
                table: "Pedido",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "fechaEmision",
                table: "Pedido",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "formaPago",
                table: "Factura",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "Detalle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "subtotal",
                table: "Detalle",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "tipo",
                table: "Detalle",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Pedido_pedidoid",
                table: "Detalle",
                column: "pedidoid",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Detalle_Pedido_pedidoid",
                table: "Detalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingrediente_Pizza_Pizzaid",
                table: "Ingrediente");

            migrationBuilder.DropColumn(
                name: "nombre",
                table: "Pizza");

            migrationBuilder.DropColumn(
                name: "cliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "demora",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "estado",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "fechaEmision",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "formaPago",
                table: "Factura");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "subtotal",
                table: "Detalle");

            migrationBuilder.DropColumn(
                name: "tipo",
                table: "Detalle");

            migrationBuilder.RenameColumn(
                name: "nombre",
                table: "Ingrediente",
                newName: "descipcion");

            migrationBuilder.RenameColumn(
                name: "Pizzaid",
                table: "Ingrediente",
                newName: "Variedadid");

            migrationBuilder.RenameIndex(
                name: "IX_Ingrediente_Pizzaid",
                table: "Ingrediente",
                newName: "IX_Ingrediente_Variedadid");

            migrationBuilder.RenameColumn(
                name: "pedidoid",
                table: "Detalle",
                newName: "Pedidoid");

            migrationBuilder.RenameColumn(
                name: "tamaño",
                table: "Detalle",
                newName: "montoUnitario");

            migrationBuilder.RenameIndex(
                name: "IX_Detalle_pedidoid",
                table: "Detalle",
                newName: "IX_Detalle_Pedidoid");

            migrationBuilder.AddColumn<int>(
                name: "Menuid",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tamañoid",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "tipoPizzaid",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "variedadid",
                table: "Pizza",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "clienteid",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "estadoid",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "total",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "monto",
                table: "Factura",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    apellido = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_clienteid",
                table: "Pedido",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_estadoid",
                table: "Pedido",
                column: "estadoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalle_Pedido_Pedidoid",
                table: "Detalle",
                column: "Pedidoid",
                principalTable: "Pedido",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingrediente_Variedad_Variedadid",
                table: "Ingrediente",
                column: "Variedadid",
                principalTable: "Variedad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_clienteid",
                table: "Pedido",
                column: "clienteid",
                principalTable: "Cliente",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Estado_estadoid",
                table: "Pedido",
                column: "estadoid",
                principalTable: "Estado",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Menu_Menuid",
                table: "Pizza",
                column: "Menuid",
                principalTable: "Menu",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Tamaño_tamañoid",
                table: "Pizza",
                column: "tamañoid",
                principalTable: "Tamaño",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_TipoPizza_tipoPizzaid",
                table: "Pizza",
                column: "tipoPizzaid",
                principalTable: "TipoPizza",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pizza_Variedad_variedadid",
                table: "Pizza",
                column: "variedadid",
                principalTable: "Variedad",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
