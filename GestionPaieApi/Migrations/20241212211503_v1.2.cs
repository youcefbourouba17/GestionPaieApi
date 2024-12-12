using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v12 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precarite",
                table: "FicheAttachemnts");

            migrationBuilder.DropColumn(
                name: "PrimePers",
                table: "FicheAttachemnts");

            migrationBuilder.AddColumn<int>(
                name: "Precarite",
                table: "Employes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Precarite",
                table: "Employes");

            migrationBuilder.AddColumn<int>(
                name: "Precarite",
                table: "FicheAttachemnts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PrimePers",
                table: "FicheAttachemnts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
