using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class _20190612_BeneficiarioEsHabilitado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "HojaRutaDocumentos",
            //    schema: "Planificacion");

//            migrationBuilder.RenameColumn(
//                name: "NuemroPeriodos",
//                schema: "Ventas",
//                table: "VentaTarifario",
//                newName: "NumeroPeriodos");
//
//            migrationBuilder.RenameColumn(
//                name: "IdProcesoNivel2",
//                schema: "Ventas",
//                table: "VentaTarifario",
//                newName: "IdProceso");
//
//            migrationBuilder.RenameColumn(
//                name: "Justificacion",
//                schema: "Ventas",
//                table: "VentaSolicitud",
//                newName: "Descripcion");
//
//            migrationBuilder.AddColumn<int>(
//                name: "Escala",
//                schema: "Ventas",
//                table: "VentaTarifario",
//                nullable: false,
//                defaultValue: 0);
//
//            migrationBuilder.AddColumn<bool>(
//                name: "EsHabilitado",
//                schema: "RRHH",
//                table: "Beneficiario",
//                nullable: false,
//                defaultValue: false);
//
//            migrationBuilder.DropTable(
//                name: "RubroIngreso",
//                schema: "Planificacion");
//
//            migrationBuilder.CreateTable(
//                name: "RubroIngreso",
//                schema: "Planificacion",
//                columns: table => new
//                {
//                    IdRubroIngreso = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    IdRubroIngresoPadre = table.Column<int>(nullable: false),
//                    Nivel = table.Column<int>(nullable: false),
//                    EsUltimoNivel = table.Column<bool>(nullable: false),
//                    Gestion = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_RubroIngreso", x => x.IdRubroIngreso);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "BeneficiarioCategoria",
//                schema: "RRHH",
//                columns: table => new
//                {
//                    IdBeneficiarioCategoria = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Porcentaje = table.Column<decimal>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_BeneficiarioCategoria", x => x.IdBeneficiarioCategoria);
//                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RubroIngreso",
                schema: "Planificacion");

            migrationBuilder.DropTable(
                name: "BeneficiarioCategoria",
                schema: "RRHH");

            migrationBuilder.DropColumn(
                name: "Escala",
                schema: "Ventas",
                table: "VentaTarifario");

            //migrationBuilder.DropColumn(
            //    name: "EsHabilitado",
            //    schema: "RRHH",
            //    table: "Beneficiario");

            //migrationBuilder.RenameColumn(
            //    name: "NumeroPeriodos",
            //    schema: "Ventas",
            //    table: "VentaTarifario",
            //    newName: "NuemroPeriodos");

            //migrationBuilder.RenameColumn(
            //    name: "IdProceso",
            //    schema: "Ventas",
            //    table: "VentaTarifario",
            //    newName: "IdProcesoNivel2");

            //migrationBuilder.RenameColumn(
            //    name: "Descripcion",
            //    schema: "Ventas",
            //    table: "VentaSolicitud",
            //    newName: "Justificacion");

            migrationBuilder.CreateTable(
                name: "HojaRutaDocumentos",
                schema: "Planificacion",
                columns: table => new
                {
                    IdHojaRutaDocumentos = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CiteRespaldo = table.Column<string>(nullable: true),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    HoraRegistro = table.Column<string>(nullable: true),
                    IdDocumentoRespaldo = table.Column<int>(nullable: false),
                    IdEstadoRegistro = table.Column<int>(nullable: false),
                    IdHojaRuta = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaRutaDocumentos", x => x.IdHojaRutaDocumentos);
                });
        }
    }
}
