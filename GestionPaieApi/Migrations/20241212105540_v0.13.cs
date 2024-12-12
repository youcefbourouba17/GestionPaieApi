using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v013 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pointage_Employes_EmployeId",
                table: "Pointage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pointage",
                table: "Pointage");

            migrationBuilder.RenameTable(
                name: "Pointage",
                newName: "Pointages");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pointages",
                table: "Pointages",
                columns: new[] { "EmployeId", "Date" });

            migrationBuilder.CreateTable(
                name: "FicheAttachemnts",
                columns: table => new
                {
                    FaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JourTravaillee = table.Column<int>(type: "int", nullable: false),
                    PrimePers = table.Column<int>(type: "int", nullable: false),
                    Precarite = table.Column<int>(type: "int", nullable: false),
                    AllocationFamiliale = table.Column<int>(type: "int", nullable: false),
                    Remboursement = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FicheAttachemnts", x => x.FaID);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pointages_Employes_EmployeId",
                table: "Pointages",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "NSS",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pointages_Employes_EmployeId",
                table: "Pointages");

            migrationBuilder.DropTable(
                name: "FicheAttachemnts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pointages",
                table: "Pointages");

            migrationBuilder.RenameTable(
                name: "Pointages",
                newName: "Pointage");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pointage",
                table: "Pointage",
                columns: new[] { "EmployeId", "Date" });

            migrationBuilder.AddForeignKey(
                name: "FK_Pointage_Employes_EmployeId",
                table: "Pointage",
                column: "EmployeId",
                principalTable: "Employes",
                principalColumn: "NSS",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
