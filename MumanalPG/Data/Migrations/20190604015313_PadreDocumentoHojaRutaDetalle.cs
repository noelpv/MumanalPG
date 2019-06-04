using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class PadreDocumentoHojaRutaDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          
            migrationBuilder.InsertData(
                table: "Documentos",
                schema: "Correspondencia",
                columns: new[] {"Id", "FuncionarioOrigenId", "FuncionarioDestinoId","CargoFuncionarioOrigen", "CargoFuncionarioDestino",
                    "AreaFuncionarioOrigen", "AreaFuncionarioDestino","Referencia", "Fecha","Contenido", "IdEstadoRegistro", 
                    "IdUsuario", "FechaRegistro", "TipoId"},
                values: new object[] {0,-1, -1, "-", "-", "-", "-", "NINGUNO", DateTime.Now, "-", 2, -1, DateTime.Now, 1});
            
            migrationBuilder.AddColumn<int>(
                name: "DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Padre",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                nullable: false,
                defaultValue: 0);

           
            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "DocumentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_HojaRutaDetalle_Documentos_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "DocumentoId",
                principalSchema: "Correspondencia",
                principalTable: "Documentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HojaRutaDetalle_Documentos_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle");

           
            migrationBuilder.DropIndex(
                name: "IX_HojaRutaDetalle_DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle");

            migrationBuilder.DropColumn(
                name: "DocumentoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle");

            migrationBuilder.DropColumn(
                name: "Padre",
                schema: "Correspondencia",
                table: "HojaRutaDetalle");

        }
    }
}
