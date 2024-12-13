using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSync.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EPSSaludId",
                table: "Pacientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EPSaluds",
                columns: table => new
                {
                    EPSSaludId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NombreEPS = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DireccionEPS = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TelefonoEPS = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailEPS = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TipoEPS = table.Column<int>(type: "int", nullable: false),
                    PaginaWeb = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FechaRegistro = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EPSaluds", x => x.EPSSaludId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_EPSSaludId",
                table: "Pacientes",
                column: "EPSSaludId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_EPSaluds_EPSSaludId",
                table: "Pacientes",
                column: "EPSSaludId",
                principalTable: "EPSaluds",
                principalColumn: "EPSSaludId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_EPSaluds_EPSSaludId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "EPSaluds");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_EPSSaludId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "EPSSaludId",
                table: "Pacientes");
        }
    }
}
