using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class HojaRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaRuta",
                schema: "Planificacion");
            
            migrationBuilder.CreateTable(
                name: "HojaRuta",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    UnidadEjecutoraId = table.Column<int>(nullable: false),
                    OrigenId = table.Column<int>(nullable: false),
                    Referencia = table.Column<string>(nullable: false),
                    CiteTramite = table.Column<string>(nullable: false),
                    CiteFecha = table.Column<DateTime>(nullable: false, defaultValueSql: "now()"),
                    NroFojas = table.Column<int>(nullable: false, defaultValue: 0),
                    SolicitudCodigo = table.Column<int>(nullable: false, defaultValue: 0),
                    Gestion = table.Column<int>(nullable: false, defaultValue: 0),
                    CiteHojaRuta = table.Column<string>(nullable: false),
                    TipoHojaRuta = table.Column<string>(nullable: true, defaultValue: "INTERNA"),
                    IdEstadoRegistro = table.Column<int>(nullable: false, defaultValue: 0),
                    IdUsuario = table.Column<int>(nullable: false, defaultValue: 0),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaRuta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HojaRuta_Beneficiario_OrigenId",
                        column: x => x.OrigenId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaRuta_UnidadEjecutora_UnidadEjecutoraId",
                        column: x => x.UnidadEjecutoraId,
                        principalSchema: "RRHH",
                        principalTable: "UnidadEjecutora",
                        principalColumn: "IdUnidadEjecutora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojaRuta_OrigenId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "OrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_HojaRuta_UnidadEjecutoraId",
                schema: "Correspondencia",
                table: "HojaRuta",
                column: "UnidadEjecutoraId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaRuta",
                schema: "Correspondencia");
        }
    }
}
