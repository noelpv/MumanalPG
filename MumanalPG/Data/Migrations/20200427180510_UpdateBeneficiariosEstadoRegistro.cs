using Microsoft.EntityFrameworkCore.Migrations;
using MumanalPG.Utility;

namespace MumanalPG.Data.Migrations
{
    public partial class UpdateBeneficiariosEstadoRegistro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            var sql = $"UPDATE {c}RRHH{c}.{c}Beneficiario{c} SET {c}IdEstadoRegistro{c} = {Constantes.Registrado} WHERE {c}IdEstadoRegistro{c} IS NULL";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
