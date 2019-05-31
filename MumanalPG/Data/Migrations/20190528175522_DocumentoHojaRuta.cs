using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class DocumentoHojaRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HojaRuta_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "DocumentoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRuta_Documentos_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "DocumentoId",
                principalSchema: "Correspondencia",
                principalTable: "Documentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HojaRuta_Documentos_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropIndex(
                name: "IX_HojaRuta_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta");
        }
    }
}
