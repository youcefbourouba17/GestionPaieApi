using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BulletinDeSalaires",
                columns: table => new
                {
                    Id_FichAtachemnt = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FicheAttachemntMonth = table.Column<int>(type: "int", nullable: true),
                    FicheAttachemntYear = table.Column<int>(type: "int", nullable: true),
                    FicheAttachemntEmployeeID = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    NSS_EMPLOYE = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Mois = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Salaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinDeSalaires", x => x.Id_FichAtachemnt);
                    table.ForeignKey(
                        name: "FK_BulletinDeSalaires_Employes_NSS_EMPLOYE",
                        column: x => x.NSS_EMPLOYE,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BulletinDeSalaires_FicheAttachemnts_FicheAttachemntMonth_FicheAttachemntYear_FicheAttachemntEmployeeID",
                        columns: x => new { x.FicheAttachemntMonth, x.FicheAttachemntYear, x.FicheAttachemntEmployeeID },
                        principalTable: "FicheAttachemnts",
                        principalColumns: new[] { "Month", "Year", "EmployeeID" });
                });

            migrationBuilder.CreateTable(
                name: "GrilleSalaires",
                columns: table => new
                {
                    NSS_EMPLOYE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeNSS = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    SalaireNet = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Grd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrilleSalaires", x => x.NSS_EMPLOYE);
                    table.ForeignKey(
                        name: "FK_GrilleSalaires_Employes_EmployeNSS",
                        column: x => x.EmployeNSS,
                        principalTable: "Employes",
                        principalColumn: "NSS");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_FicheAttachemntMonth_FicheAttachemntYear_FicheAttachemntEmployeeID",
                table: "BulletinDeSalaires",
                columns: new[] { "FicheAttachemntMonth", "FicheAttachemntYear", "FicheAttachemntEmployeeID" });

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_NSS_EMPLOYE",
                table: "BulletinDeSalaires",
                column: "NSS_EMPLOYE");

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_EmployeNSS",
                table: "GrilleSalaires",
                column: "EmployeNSS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BulletinDeSalaires");

            migrationBuilder.DropTable(
                name: "GrilleSalaires");
        }
    }
}
