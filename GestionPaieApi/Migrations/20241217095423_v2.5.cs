using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v25 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulletinDeSalaires_Employes_NSS_EMPLOYE",
                table: "BulletinDeSalaires");

            migrationBuilder.DropIndex(
                name: "IX_BulletinDeSalaires_NSS_EMPLOYE",
                table: "BulletinDeSalaires");

            migrationBuilder.DropColumn(
                name: "NSS_EMPLOYE",
                table: "BulletinDeSalaires");

            migrationBuilder.AddColumn<string>(
                name: "GrilleSalaireID",
                table: "BulletinDeSalaires",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_GrilleSalaireID",
                table: "BulletinDeSalaires",
                column: "GrilleSalaireID");

            migrationBuilder.AddForeignKey(
                name: "FK_BulletinDeSalaires_GrilleSalaires_GrilleSalaireID",
                table: "BulletinDeSalaires",
                column: "GrilleSalaireID",
                principalTable: "GrilleSalaires",
                principalColumn: "NSS_EMPLOYE",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulletinDeSalaires_GrilleSalaires_GrilleSalaireID",
                table: "BulletinDeSalaires");

            migrationBuilder.DropIndex(
                name: "IX_BulletinDeSalaires_GrilleSalaireID",
                table: "BulletinDeSalaires");

            migrationBuilder.DropColumn(
                name: "GrilleSalaireID",
                table: "BulletinDeSalaires");

            migrationBuilder.AddColumn<string>(
                name: "NSS_EMPLOYE",
                table: "BulletinDeSalaires",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_NSS_EMPLOYE",
                table: "BulletinDeSalaires",
                column: "NSS_EMPLOYE");

            migrationBuilder.AddForeignKey(
                name: "FK_BulletinDeSalaires_Employes_NSS_EMPLOYE",
                table: "BulletinDeSalaires",
                column: "NSS_EMPLOYE",
                principalTable: "Employes",
                principalColumn: "NSS",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
