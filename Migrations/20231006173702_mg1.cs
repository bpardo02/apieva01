using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace apitest.Migrations
{
    public partial class mg1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TblDepartamentos",
                columns: table => new
                {
                    Cod_Dpto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblDepartamentos", x => x.Cod_Dpto);
                });

            migrationBuilder.CreateTable(
                name: "TblTrabajadores",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cod_Dpto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblTrabajadores", x => x.Rut);
                    table.ForeignKey(
                        name: "FK_TblTrabajadores_TblDepartamentos_Cod_Dpto",
                        column: x => x.Cod_Dpto,
                        principalTable: "TblDepartamentos",
                        principalColumn: "Cod_Dpto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblCargas",
                columns: table => new
                {
                    Rut = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RutTrabajador = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblCargas", x => x.Rut);
                    table.ForeignKey(
                        name: "FK_TblCargas_TblTrabajadores_RutTrabajador",
                        column: x => x.RutTrabajador,
                        principalTable: "TblTrabajadores",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TblContactos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rut = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comuna = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutTrabajador = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblContactos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TblContactos_TblTrabajadores_RutTrabajador",
                        column: x => x.RutTrabajador,
                        principalTable: "TblTrabajadores",
                        principalColumn: "Rut",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TblCargas_RutTrabajador",
                table: "TblCargas",
                column: "RutTrabajador");

            migrationBuilder.CreateIndex(
                name: "IX_TblContactos_RutTrabajador",
                table: "TblContactos",
                column: "RutTrabajador");

            migrationBuilder.CreateIndex(
                name: "IX_TblTrabajadores_Cod_Dpto",
                table: "TblTrabajadores",
                column: "Cod_Dpto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblCargas");

            migrationBuilder.DropTable(
                name: "TblContactos");

            migrationBuilder.DropTable(
                name: "TblTrabajadores");

            migrationBuilder.DropTable(
                name: "TblDepartamentos");
        }
    }
}
