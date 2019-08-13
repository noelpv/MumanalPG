using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class HojaRutaDetalleDefault : Migration
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
            
            migrationBuilder.InsertData(
                table: "HojaRuta",
                schema: "Correspondencia",
                columns: new[] {"Id", "UnidadEjecutoraId", "OrigenId","Referencia", "CiteTramite", "CiteHojaRuta"},
                values: new object[] {0,1, -1, "-", "-", "-"});
            
            migrationBuilder.InsertData(
                table: "HojaRutaDetalle",
                schema: "Correspondencia",
                columns: new[] {"Id", "HojaRutaId", "AreaOrigenId","AreaDestinoId", "FunOrgId", "FunDstId"},
                values: new object[] {0,0,1,1, -1,-1});
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
    }
}
