using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EmployeResponsabilites",
                newName: "EmployeResponsabilitesId");

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

            migrationBuilder.CreateIndex(
                name: "IX_LettreAccompagnee_EmployeId",
                table: "LettreAccompagnee",
                column: "EmployeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LettreAccompagnee");

            migrationBuilder.RenameColumn(
                name: "EmployeResponsabilitesId",
                table: "EmployeResponsabilites",
                newName: "Id");
        }
    }
}
