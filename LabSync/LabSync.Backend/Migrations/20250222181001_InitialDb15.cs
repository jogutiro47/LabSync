using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSync.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reporte",
                table: "Muestras");

            migrationBuilder.RenameColumn(
                name: "FechaRegistra",
                table: "ResultadoMuestras",
                newName: "FechaReporte");

            migrationBuilder.RenameColumn(
                name: "nroAdmision",
                table: "Muestras",
                newName: "NroAdmision");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRegistro",
                table: "Muestras",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaRegistro",
                table: "Muestras");

            migrationBuilder.RenameColumn(
                name: "FechaReporte",
                table: "ResultadoMuestras",
                newName: "FechaRegistra");

            migrationBuilder.RenameColumn(
                name: "NroAdmision",
                table: "Muestras",
                newName: "nroAdmision");

            migrationBuilder.AddColumn<DateTime>(
                name: "Reporte",
                table: "Muestras",
                type: "datetime(6)",
                nullable: true);
        }
    }
}
