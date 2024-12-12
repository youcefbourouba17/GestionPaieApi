using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeNSS",
                table: "FicheAttachemnts",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeID",
                table: "FicheAttachemnts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAttachemnts_EmployeNSS",
                table: "FicheAttachemnts",
                column: "EmployeNSS");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAttachemnts_Employes_EmployeNSS",
                table: "FicheAttachemnts",
                column: "EmployeNSS",
                principalTable: "Employes",
                principalColumn: "NSS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheAttachemnts_Employes_EmployeNSS",
                table: "FicheAttachemnts");

            migrationBuilder.DropIndex(
                name: "IX_FicheAttachemnts_EmployeNSS",
                table: "FicheAttachemnts");

            migrationBuilder.DropColumn(
                name: "EmployeNSS",
                table: "FicheAttachemnts");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "FicheAttachemnts");
        }
    }
}
