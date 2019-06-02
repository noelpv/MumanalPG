using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class HojaRutaForeingKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_HojaRuta_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta");
            
            migrationBuilder.DropIndex(
                name: "IX_HojaRuta_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta");
            
            migrationBuilder.CreateIndex(
                name: "IX_HojaRuta_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "UnidadEjecutoraId");
            
            migrationBuilder.CreateIndex(
                name: "IX_HojaRuta_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "DocumentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
