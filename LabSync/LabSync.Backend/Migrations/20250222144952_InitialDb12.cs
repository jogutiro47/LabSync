using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSync.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResultadoMuestraResultadoId",
                table: "Muestras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Medicos",
                columns: table => new
                {
                    MedicoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Identificacion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nombres = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Apellidos = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Profesion = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NroTarjetaProfesional = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrigenMedico = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicos", x => x.MedicoId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ResultadoMuestras",
                columns: table => new
                {
                    ResultadoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ResultadoMacro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResultadoMicro = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ResultadoDiagnostico = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistra = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    MedicoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResultadoMuestras", x => x.ResultadoId);
                    table.ForeignKey(
                        name: "FK_ResultadoMuestras_Medicos_MedicoId",
                        column: x => x.MedicoId,
                        principalTable: "Medicos",
                        principalColumn: "MedicoId",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Muestras_ResultadoMuestraResultadoId",
                table: "Muestras",
                column: "ResultadoMuestraResultadoId");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoMuestras_MedicoId",
                table: "ResultadoMuestras",
                column: "MedicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muestras_ResultadoMuestras_ResultadoMuestraResultadoId",
                table: "Muestras",
                column: "ResultadoMuestraResultadoId",
                principalTable: "ResultadoMuestras",
                principalColumn: "ResultadoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muestras_ResultadoMuestras_ResultadoMuestraResultadoId",
                table: "Muestras");

            migrationBuilder.DropTable(
                name: "ResultadoMuestras");

            migrationBuilder.DropTable(
                name: "Medicos");

            migrationBuilder.DropIndex(
                name: "IX_Muestras_ResultadoMuestraResultadoId",
                table: "Muestras");

            migrationBuilder.DropColumn(
                name: "ResultadoMuestraResultadoId",
                table: "Muestras");
        }
    }
}
