using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class FixUnidadEjecutora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            var sql = $"UPDATE {c}RRHH{c}.{c}UnidadEjecutora{c} SET {c}IdUnidadEjecutoraPadre{c} = 0 WHERE {c}IdUnidadEjecutoraPadre{c} IS NULL";

            migrationBuilder.Sql(sql);
            
            migrationBuilder.AlterColumn<int>(
                name: "IdUnidadEjecutoraPadre",
                schema: "RRHH",
                table: "UnidadEjecutora",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
