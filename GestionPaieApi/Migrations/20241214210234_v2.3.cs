using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v23 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PRC",
                table: "FicheAttachemnts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PRI",
                table: "FicheAttachemnts",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PRC",
                table: "FicheAttachemnts");

            migrationBuilder.DropColumn(
                name: "PRI",
                table: "FicheAttachemnts");
        }
    }
}
