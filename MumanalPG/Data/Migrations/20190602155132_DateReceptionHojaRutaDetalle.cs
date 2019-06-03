using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class DateReceptionHojaRutaDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.AddColumn<DateTime>(
                name: "FechaRecepcion",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.DropColumn(
                name: "FechaRecepcion",
                schema: "Correspondencia",
                table: "HojaRutaDetalle");
        }
    }
}
