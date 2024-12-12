using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts",
                columns: new[] { "Month", "Year", "EmployeeID" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts",
                columns: new[] { "Month", "Year" });
        }
    }
}
