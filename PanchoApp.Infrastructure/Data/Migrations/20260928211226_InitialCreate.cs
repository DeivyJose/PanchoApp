using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PanchoApp.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 120, nullable: false),
                    Telefono = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Correo = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Direccion = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    FechaRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Activo = table.Column<bool>(type: "INTEGER", nullable: false),
                    Observaciones = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 80, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Razas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", maxLength: 250, nullable: true),
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false),
                    EspecieId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Razas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Razas_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mascotas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Sexo = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Color = table.Column<string>(type: "TEXT", maxLength: 80, nullable: true),
                    Peso = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    FotoRuta = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    NivelAgresividad = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Esterilizado = table.Column<bool>(type: "INTEGER", nullable: false),
                    Microchip = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TipoAlimentacion = table.Column<string>(type: "TEXT", maxLength: 150, nullable: true),
                    Alergias = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Enfermedades = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    MedicamentosActuales = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Observaciones = table.Column<string>(type: "TEXT", maxLength: 700, nullable: true),
                    Activa = table.Column<bool>(type: "INTEGER", nullable: false),
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    EspecieId = table.Column<int>(type: "INTEGER", nullable: false),
                    RazaId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascotas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mascotas_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Especies_EspecieId",
                        column: x => x.EspecieId,
                        principalTable: "Especies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mascotas_Razas_RazaId",
                        column: x => x.RazaId,
                        principalTable: "Razas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_ClienteID",
                table: "Mascotas",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_EspecieId",
                table: "Mascotas",
                column: "EspecieId");

            migrationBuilder.CreateIndex(
                name: "IX_Mascotas_RazaId",
                table: "Mascotas",
                column: "RazaId");

            migrationBuilder.CreateIndex(
                name: "IX_Razas_EspecieId",
                table: "Razas",
                column: "EspecieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mascotas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Razas");

            migrationBuilder.DropTable(
                name: "Especies");
        }
    }
}
