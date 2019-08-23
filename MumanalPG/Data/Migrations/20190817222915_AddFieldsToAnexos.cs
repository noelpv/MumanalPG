using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class AddFieldsToAnexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NombreArchivo",
                schema: "Correspondencia",
                table: "Anexos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Size",
                schema: "Correspondencia",
                table: "Anexos",
                nullable: false,
                defaultValue: 0);
            
            migrationBuilder.InsertData(
                table: "HojaRuta",
                schema: "Correspondencia",
                columns: new[] {"Id", "UnidadEjecutoraId", "OrigenId","Referencia", "CiteTramite", "CiteHojaRuta"},
                values: new object[] {0,1, -1, "-", "-", "-"});
            
            migrationBuilder.InsertData(
                table: "HojaRutaDetalle",
                schema: "Correspondencia",
                columns: new[] {"Id", "HojaRutaId", "AreaOrigenId","AreaDestinoId", "FunOrgId", "FunDstId"},
                values: new object[] {0,0,1,1, -1,-1});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NombreArchivo",
                schema: "Correspondencia",
                table: "Anexos");

            migrationBuilder.DropColumn(
                name: "Size",
                schema: "Correspondencia",
                table: "Anexos");
        }
    }
}
