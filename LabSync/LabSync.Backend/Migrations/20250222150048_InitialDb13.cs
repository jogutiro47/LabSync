using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSync.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb13 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Muestras_ResultadoMuestras_ResultadoMuestraResultadoId",
                table: "Muestras");

            migrationBuilder.DropIndex(
                name: "IX_Muestras_ResultadoMuestraResultadoId",
                table: "Muestras");

            migrationBuilder.DropColumn(
                name: "ResultadoMuestraResultadoId",
                table: "Muestras");

            migrationBuilder.AddColumn<int>(
                name: "MuestraId",
                table: "ResultadoMuestras",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RutaFirma",
                table: "Medicos",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ResultadoMuestras_MuestraId",
                table: "ResultadoMuestras",
                column: "MuestraId");

            migrationBuilder.AddForeignKey(
                name: "FK_ResultadoMuestras_Muestras_MuestraId",
                table: "ResultadoMuestras",
                column: "MuestraId",
                principalTable: "Muestras",
                principalColumn: "MuestraId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResultadoMuestras_Muestras_MuestraId",
                table: "ResultadoMuestras");

            migrationBuilder.DropIndex(
                name: "IX_ResultadoMuestras_MuestraId",
                table: "ResultadoMuestras");

            migrationBuilder.DropColumn(
                name: "MuestraId",
                table: "ResultadoMuestras");

            migrationBuilder.DropColumn(
                name: "RutaFirma",
                table: "Medicos");

            migrationBuilder.AddColumn<int>(
                name: "ResultadoMuestraResultadoId",
                table: "Muestras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Muestras_ResultadoMuestraResultadoId",
                table: "Muestras",
                column: "ResultadoMuestraResultadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Muestras_ResultadoMuestras_ResultadoMuestraResultadoId",
                table: "Muestras",
                column: "ResultadoMuestraResultadoId",
                principalTable: "ResultadoMuestras",
                principalColumn: "ResultadoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
