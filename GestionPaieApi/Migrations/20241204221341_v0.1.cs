using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ResponsabilitesAdministratives_Employes_EmployeNSS",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsabilitesAdministratives",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.DropIndex(
                name: "IX_ResponsabilitesAdministratives_EmployeNSS",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.DropColumn(
                name: "EmployeNSS",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.AddColumn<string>(
                name: "ResponsabiliteID",
                table: "ResponsabilitesAdministratives",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsabilitesAdministratives",
                table: "ResponsabilitesAdministratives",
                column: "ResponsabiliteID");

            migrationBuilder.CreateTable(
                name: "EmployeResponsabilites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeID = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    ResponsabiliteID = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeResponsabilites", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitesAdministratives_NomResp",
                table: "ResponsabilitesAdministratives",
                column: "NomResp",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeResponsabilites_EmployeID",
                table: "EmployeResponsabilites",
                column: "EmployeID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeResponsabilites_ResponsabiliteID",
                table: "EmployeResponsabilites",
                column: "ResponsabiliteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeResponsabilites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResponsabilitesAdministratives",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.DropIndex(
                name: "IX_ResponsabilitesAdministratives_NomResp",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.DropColumn(
                name: "ResponsabiliteID",
                table: "ResponsabilitesAdministratives");

            migrationBuilder.AddColumn<string>(
                name: "EmployeNSS",
                table: "ResponsabilitesAdministratives",
                type: "nvarchar(20)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResponsabilitesAdministratives",
                table: "ResponsabilitesAdministratives",
                column: "NomResp");

            migrationBuilder.CreateIndex(
                name: "IX_ResponsabilitesAdministratives_EmployeNSS",
                table: "ResponsabilitesAdministratives",
                column: "EmployeNSS");

            migrationBuilder.AddForeignKey(
                name: "FK_ResponsabilitesAdministratives_Employes_EmployeNSS",
                table: "ResponsabilitesAdministratives",
                column: "EmployeNSS",
                principalTable: "Employes",
                principalColumn: "NSS");
        }
    }
}
