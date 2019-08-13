using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class AnexosHojaRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos",
                column: "HojaRutaId");
            
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

           
            migrationBuilder.DropIndex(
                name: "IX_Anexos_HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos");

           

            migrationBuilder.DropColumn(
                name: "HojaRutaId",
                schema: "Correspondencia",
                table: "Anexos");

            
        }
    }
}
