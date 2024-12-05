using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeResponsabilites_Employes_EmployeNSS",
                table: "EmployeResponsabilites");

            migrationBuilder.DropIndex(
                name: "IX_EmployeResponsabilites_EmployeNSS",
                table: "EmployeResponsabilites");

            migrationBuilder.DropColumn(
                name: "ResponsabilitePrincipalID",
                table: "Employes");

            migrationBuilder.DropColumn(
                name: "EmployeNSS",
                table: "EmployeResponsabilites");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ResponsabilitePrincipalID",
                table: "Employes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployeNSS",
                table: "EmployeResponsabilites",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeResponsabilites_EmployeNSS",
                table: "EmployeResponsabilites",
                column: "EmployeNSS",
                unique: true,
                filter: "[EmployeNSS] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeResponsabilites_Employes_EmployeNSS",
                table: "EmployeResponsabilites",
                column: "EmployeNSS",
                principalTable: "Employes",
                principalColumn: "NSS");
        }
    }
}
