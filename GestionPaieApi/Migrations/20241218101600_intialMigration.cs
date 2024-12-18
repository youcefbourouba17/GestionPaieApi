using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class intialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employes",
                columns: table => new
                {
                    NSS = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Prenom = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateNaissance = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LieuNaissance = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sexe = table.Column<int>(type: "int", nullable: true),
                    SituationFamiliale = table.Column<int>(type: "int", maxLength: 20, nullable: true),
                    Adresse = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateRecrutement = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FonctionPrincipale = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    NombreEnfants = table.Column<int>(type: "int", nullable: true),
                    Categorie = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Section = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TauxIndemniteNuisance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PrimeVariable = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Precarite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.NSS);
                });

            migrationBuilder.CreateTable(
                name: "ResponsabilitesAdministratives",
                columns: table => new
                {
                    ResponsabiliteID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NomResp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsabilitesAdministratives", x => x.ResponsabiliteID);
                });

            migrationBuilder.CreateTable(
                name: "FicheAttachemnts",
                columns: table => new
                {
                    EmployeeID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    FaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomEtPrenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JourTravaillee = table.Column<int>(type: "int", nullable: false),
                    AllocationFamiliale = table.Column<int>(type: "int", nullable: true),
                    Remboursement = table.Column<double>(type: "float", nullable: false),
                    PRI = table.Column<int>(type: "int", nullable: false),
                    PRC = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheAttachemnts", x => new { x.Month, x.Year, x.EmployeeID });
                    table.ForeignKey(
                        name: "FK_FicheAttachemnts_Employes_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GrilleSalaires",
                columns: table => new
                {
                    GrilleSalaire_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NSS_EMPLOYE = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeNSS = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    BaseSalary = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Grd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrilleSalaires", x => x.GrilleSalaire_Id);
                    table.ForeignKey(
                        name: "FK_GrilleSalaires_Employes_EmployeNSS",
                        column: x => x.EmployeNSS,
                        principalTable: "Employes",
                        principalColumn: "NSS");
                });

            migrationBuilder.CreateTable(
                name: "LettreAccompagnee",
                columns: table => new
                {
                    DemandeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    TypeChangement = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Raison = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DateDemande = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Statut = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Commentaires = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LettreAccompagnee", x => x.DemandeId);
                    table.ForeignKey(
                        name: "FK_LettreAccompagnee_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pointages",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DebutMatinee = table.Column<TimeSpan>(type: "time", nullable: true),
                    FinMatinee = table.Column<TimeSpan>(type: "time", nullable: true),
                    DebutApresMidi = table.Column<TimeSpan>(type: "time", nullable: true),
                    FinApresMidi = table.Column<TimeSpan>(type: "time", nullable: true),
                    DureeDePause = table.Column<TimeSpan>(type: "time", nullable: true),
                    HeuresSupplementaires = table.Column<double>(type: "float", nullable: true),
                    HeuresTotales = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pointages", x => new { x.EmployeId, x.Date });
                    table.ForeignKey(
                        name: "FK_Pointages_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeResponsabilites",
                columns: table => new
                {
                    EmployeResponsabilitesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ResponsabiliteID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeResponsabilites", x => x.EmployeResponsabilitesId);
                    table.ForeignKey(
                        name: "FK_EmployeResponsabilites_Employes_EmployeID",
                        column: x => x.EmployeID,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeResponsabilites_ResponsabilitesAdministratives_ResponsabiliteID",
                        column: x => x.ResponsabiliteID,
                        principalTable: "ResponsabilitesAdministratives",
                        principalColumn: "ResponsabiliteID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BulletinDeSalaires",
                columns: table => new
                {
                    BulletinDeSalaireID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_FichAtachemnt = table.Column<int>(type: "int", nullable: false),
                    FicheAttachemntMonth = table.Column<int>(type: "int", nullable: false),
                    FicheAttachemntYear = table.Column<int>(type: "int", nullable: false),
                    FicheAttachemntEmployeeID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    GrilleSalaireID = table.Column<int>(type: "int", nullable: false),
                    Salaire = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulletinDeSalaires", x => x.BulletinDeSalaireID);
                    table.ForeignKey(
                        name: "FK_BulletinDeSalaires_FicheAttachemnts_FicheAttachemntMonth_FicheAttachemntYear_FicheAttachemntEmployeeID",
                        columns: x => new { x.FicheAttachemntMonth, x.FicheAttachemntYear, x.FicheAttachemntEmployeeID },
                        principalTable: "FicheAttachemnts",
                        principalColumns: new[] { "Month", "Year", "EmployeeID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BulletinDeSalaires_GrilleSalaires_GrilleSalaireID",
                        column: x => x.GrilleSalaireID,
                        principalTable: "GrilleSalaires",
                        principalColumn: "GrilleSalaire_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_FicheAttachemntMonth_FicheAttachemntYear_FicheAttachemntEmployeeID",
                table: "BulletinDeSalaires",
                columns: new[] { "FicheAttachemntMonth", "FicheAttachemntYear", "FicheAttachemntEmployeeID" });

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_GrilleSalaireID",
                table: "BulletinDeSalaires",
                column: "GrilleSalaireID");

            migrationBuilder.CreateIndex(
                name: "IX_BulletinDeSalaires_Id_FichAtachemnt",
                table: "BulletinDeSalaires",
                column: "Id_FichAtachemnt",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeResponsabilites_EmployeID",
                table: "EmployeResponsabilites",
                column: "EmployeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeResponsabilites_ResponsabiliteID",
                table: "EmployeResponsabilites",
                column: "ResponsabiliteID");

            migrationBuilder.CreateIndex(
                name: "IX_FicheAttachemnts_EmployeeID",
                table: "FicheAttachemnts",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_EmployeNSS",
                table: "GrilleSalaires",
                column: "EmployeNSS");

            migrationBuilder.CreateIndex(
                name: "IX_GrilleSalaires_NSS_EMPLOYE",
                table: "GrilleSalaires",
                column: "NSS_EMPLOYE",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LettreAccompagnee_EmployeId",
                table: "LettreAccompagnee",
                column: "EmployeId");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitesAdministratives_NomResp",
                table: "ResponsabilitesAdministratives",
                column: "NomResp",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BulletinDeSalaires");

            migrationBuilder.DropTable(
                name: "EmployeResponsabilites");

            migrationBuilder.DropTable(
                name: "LettreAccompagnee");

            migrationBuilder.DropTable(
                name: "Pointages");

            migrationBuilder.DropTable(
                name: "FicheAttachemnts");

            migrationBuilder.DropTable(
                name: "GrilleSalaires");

            migrationBuilder.DropTable(
                name: "ResponsabilitesAdministratives");

            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
