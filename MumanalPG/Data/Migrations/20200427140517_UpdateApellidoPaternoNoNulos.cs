using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class UpdateApellidoPaternoNoNulos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            var sql = $"UPDATE {c}RRHH{c}.{c}Beneficiario{c} SET {c}PrimerApellido{c} = '-' WHERE {c}PrimerApellido{c} IS NULL";

            migrationBuilder.Sql(sql);
            migrationBuilder.AlterColumn<string>(
                name: "PrimerApellido",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(string),
                defaultValue: "-",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "PrimerApellido",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
