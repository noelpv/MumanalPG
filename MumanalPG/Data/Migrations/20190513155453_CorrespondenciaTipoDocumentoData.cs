using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class CorrespondenciaTipoDocumentoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Correspondencia");
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Id", "Nombre", "Descripcion", "Estado"},
                values: new object[] {1, "Informe", "-", "ACTIVO" });
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Id", "Nombre", "Descripcion", "Estado"},
                values: new object[] {2, "Nota Interna", "-", "ACTIVO" });
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Id", "Nombre", "Descripcion", "Estado"},
                values: new object[] {3, "Nota Externa", "-", "ACTIVO" });
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Id", "Nombre", "Descripcion", "Estado"},
                values: new object[] {4, "Memorandum", "-", "ACTIVO" });
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Id", "Nombre", "Descripcion", "Estado"},
                values: new object[] { 5,"Comunicación Interna", "-", "ACTIVO"  });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
