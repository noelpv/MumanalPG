using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class CorreccionSecuenciaUnidadEjecutora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RestartSequence(
                name: "UnidadEjecutora_IdUnidadEjecutora_seq",
                schema: "RRHH",
                startValue: 100
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
