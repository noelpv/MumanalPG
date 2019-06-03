using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class PrioridadCorrespondenciaInterna : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HojaRuta_Beneficiario_OrigenId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropForeignKey(
                name: "FK_HojaRuta_UnidadEjecutora_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.AddColumn<string>(
                name: "Prioridad",
                schema: "Correspondencia",
                table: "HojaRuta",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRuta_Beneficiario_OrigenId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "OrigenId",
                principalSchema: "RRHH",
                principalTable: "Beneficiario",
                principalColumn: "IdBeneficiario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRuta_UnidadEjecutora_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "UnidadEjecutoraId",
                principalSchema: "RRHH",
                principalTable: "UnidadEjecutora",
                principalColumn: "IdUnidadEjecutora",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HojaRuta_Beneficiario_OrigenId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropForeignKey(
                name: "FK_HojaRuta_UnidadEjecutora_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropColumn(
                name: "Prioridad",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRuta_Beneficiario_OrigenId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "OrigenId",
                principalSchema: "RRHH",
                principalTable: "Beneficiario",
                principalColumn: "IdBeneficiario",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRuta_UnidadEjecutora_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "UnidadEjecutoraId",
                principalSchema: "RRHH",
                principalTable: "UnidadEjecutora",
                principalColumn: "IdUnidadEjecutora",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
