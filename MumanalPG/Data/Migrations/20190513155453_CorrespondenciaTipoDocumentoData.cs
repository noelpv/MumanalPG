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
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Informe", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Nota Interna", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] { "Nota Externa", "-" ,0,1});
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] { "Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Memorandum", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "TipoDocumento",
                schema: "Correspondencia",
                columns: new[] { "Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Comunicación Interna", "-",0,1});

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
