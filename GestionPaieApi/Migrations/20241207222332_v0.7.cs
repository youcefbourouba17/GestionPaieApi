using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v07 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pointage",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EmployeId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    DebutMatinee = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinMatinee = table.Column<TimeSpan>(type: "time", nullable: false),
                    DebutApresMidi = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinApresMidi = table.Column<TimeSpan>(type: "time", nullable: false),
                    DureeDePause = table.Column<TimeSpan>(type: "time", nullable: false),
                    HeuresSupplementaires = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pointage", x => new { x.EmployeId, x.Date });
                    table.ForeignKey(
                        name: "FK_Pointage_Employes_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Employes",
                        principalColumn: "NSS",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pointage");
        }
    }
}
