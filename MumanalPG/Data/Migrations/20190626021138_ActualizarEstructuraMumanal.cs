using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class ActualizarEstructuraMumanal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            
            var sql = $"DELETE FROM {c}Correspondencia{c}.{c}HojaRutaDetalle{c};";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}Correspondencia{c}.{c}HojaRuta{c};";
            migrationBuilder.Sql(sql);
          
            sql = $@"UPDATE {c}RRHH{c}.{c}Beneficiario{c} SET {c}PuestoId{c} = 1;";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}AspNetUsers{c} WHERE {c}UserName{c} LIKE '%@mumanal.org';";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}RRHH{c}.{c}Puesto{c} WHERE {c}IdPuesto{c} > 1;";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}RRHH{c}.{c}UnidadEjecutora{c} WHERE {c}IdUnidadEjecutora{c} >= 100 AND {c}Sigla{c} IS NOT NULL;";
            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
