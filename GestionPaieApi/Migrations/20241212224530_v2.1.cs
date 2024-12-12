using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestionPaieApi.Migrations
{
    /// <inheritdoc />
    public partial class v21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts");

            migrationBuilder.AlterColumn<int>(
                name: "AllocationFamiliale",
                table: "FicheAttachemnts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts",
                columns: new[] { "Month", "Year" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts");

            migrationBuilder.AlterColumn<int>(
                name: "AllocationFamiliale",
                table: "FicheAttachemnts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FicheAttachemnts",
                table: "FicheAttachemnts",
                column: "FaID");
        }
    }
}
