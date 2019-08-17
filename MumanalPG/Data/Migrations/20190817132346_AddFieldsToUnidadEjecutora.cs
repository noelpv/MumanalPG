using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class AddFieldsToUnidadEjecutora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            
            var sql = $"DELETE FROM {c}Correspondencia{c}.{c}HojaRutaDetalle{c};";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}Correspondencia{c}.{c}HojaRuta{c};";
            migrationBuilder.Sql(sql);
          
            sql = $"DELETE FROM {c}AspNetUsers{c} WHERE {c}Email{c} LIKE '%@mumanal.org';";
            migrationBuilder.Sql(sql);
            
            sql = $@"DELETE FROM {c}RRHH{c}.{c}Beneficiario{c} WHERE {c}PuestoId{c} > 1;";
            migrationBuilder.Sql(sql);

            sql = $"DELETE FROM {c}RRHH{c}.{c}Puesto{c} WHERE {c}IdPuesto{c} > 1;";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}RRHH{c}.{c}UnidadEjecutora{c} WHERE {c}IdUnidadEjecutora{c} >= 100 AND {c}Sigla{c} IS NOT NULL;";
            migrationBuilder.Sql(sql);
            
            migrationBuilder.AddColumn<bool>(
                name: "EsExterna",
                schema: "RRHH",
                table: "UnidadEjecutora",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<int>(
                name: "OrdenMostrar",
                schema: "RRHH",
                table: "UnidadEjecutora",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EsExterna",
                schema: "RRHH",
                table: "UnidadEjecutora");

            migrationBuilder.DropColumn(
                name: "OrdenMostrar",
                schema: "RRHH",
                table: "UnidadEjecutora");
        }
    }
}
