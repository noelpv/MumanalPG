using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class UpdateForeingKeyAnexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_HojaRuta_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos");

            migrationBuilder.AlterColumn<int>(
                name: "HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_HojaRuta_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                column: "HojaRutaId",
                principalSchema: "Correspondencia",
                principalTable: "HojaRuta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Anexos_HojaRuta_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos");

            migrationBuilder.AlterColumn<int>(
                name: "HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Anexos_HojaRuta_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                column: "HojaRutaId",
                principalSchema: "Correspondencia",
                principalTable: "HojaRuta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
