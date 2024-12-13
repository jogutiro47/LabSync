using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSync.Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbreviaturaEPS",
                table: "EPSaluds",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AbreviaturaEPS",
                table: "EPSaluds");
        }
    }
}
