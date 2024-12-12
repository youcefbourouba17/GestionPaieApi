using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class _2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "FicheAttachemnts",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAttachemnts_EmployeeID",
                table: "FicheAttachemnts",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_FicheAttachemnts_Employes_EmployeeID",
                table: "FicheAttachemnts",
                column: "EmployeeID",
                principalTable: "Employes",
                principalColumn: "NSS",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FicheAttachemnts_Employes_EmployeeID",
                table: "FicheAttachemnts");

            migrationBuilder.DropIndex(
                name: "IX_FicheAttachemnts_EmployeeID",
                table: "FicheAttachemnts");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID",
                table: "FicheAttachemnts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddColumn<string>(
                name: "EmployeNSS",
                table: "FicheAttachemnts",
                type: "nvarchar(20)",
                nullable: true);

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
    }
}
