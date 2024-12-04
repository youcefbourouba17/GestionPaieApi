using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
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
                    PrimeVariable = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employes", x => x.NSS);
                });

            migrationBuilder.CreateTable(
                name: "ResponsabilitesAdministratives",
                columns: table => new
                {
                    NomResp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    EmployeNSS = table.Column<string>(type: "nvarchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsabilitesAdministratives", x => x.NomResp);
                    table.ForeignKey(
                        name: "FK_ResponsabilitesAdministratives_Employes_EmployeNSS",
                        column: x => x.EmployeNSS,
                        principalTable: "Employes",
                        principalColumn: "NSS");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitesAdministratives_EmployeNSS",
                table: "ResponsabilitesAdministratives",
                column: "EmployeNSS");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ResponsabilitesAdministratives");

            migrationBuilder.DropTable(
                name: "Employes");
        }
    }
}
