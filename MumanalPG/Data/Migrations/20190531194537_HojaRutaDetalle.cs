using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class HojaRutaDetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaRutaDetalle",
                schema: "Planificacion");
            
            migrationBuilder.CreateTable(
                name: "HojaRutaDetalle",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HojaRutaId = table.Column<int>(nullable: false),
                    AreaOrigenId = table.Column<int>(nullable: false),
                    AreaDestinoId = table.Column<int>(nullable: false),
                    FunOrgId = table.Column<int>(nullable: false),
                    FunDstId = table.Column<int>(nullable: false),
                    PlazoDias = table.Column<int>(nullable: false, defaultValue: 1),
                    Proveido = table.Column<string>(nullable: false, defaultValue: "-"),
                    IdEstadoRegistro = table.Column<int>(nullable: false, defaultValue: 0),
                    IdUsuario = table.Column<int>(nullable: false, defaultValue: 0),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HojaRutaDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HojaRutaDetalle_UnidadEjecutora_AreaDestinoId",
                        column: x => x.AreaDestinoId,
                        principalSchema: "RRHH",
                        principalTable: "UnidadEjecutora",
                        principalColumn: "IdUnidadEjecutora",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaRutaDetalle_UnidadEjecutora_AreaOrigenId",
                        column: x => x.AreaOrigenId,
                        principalSchema: "RRHH",
                        principalTable: "UnidadEjecutora",
                        principalColumn: "IdUnidadEjecutora",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaRutaDetalle_Beneficiario_FunDstId",
                        column: x => x.FunDstId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaRutaDetalle_Beneficiario_FunOrgId",
                        column: x => x.FunOrgId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HojaRutaDetalle_HojaRuta_HojaRutaId",
                        column: x => x.HojaRutaId,
                        principalSchema: "Correspondencia",
                        principalTable: "HojaRuta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HRDetalleInstrucciones",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    HRDetalleId = table.Column<int>(nullable: false),
                    InstruccionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HRDetalleInstrucciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HRDetalleInstrucciones_HojaRutaDetalle_HRDetalleId",
                        column: x => x.HRDetalleId,
                        principalSchema: "Correspondencia",
                        principalTable: "HojaRutaDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HRDetalleInstrucciones_Instrucciones_InstruccionId",
                        column: x => x.InstruccionId,
                        principalSchema: "Correspondencia",
                        principalTable: "Instrucciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_AreaDestinoId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "AreaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_AreaOrigenId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "AreaOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_FunDstId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "FunDstId");

            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_FunOrgId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "FunOrgId");

            migrationBuilder.CreateIndex(
                name: "IX_HojaRutaDetalle_HojaRutaId",
                schema: "Correspondencia",
                table: "HojaRutaDetalle",
                column: "HojaRutaId");

            migrationBuilder.CreateIndex(
                name: "IX_HRDetalleInstrucciones_HRDetalleId",
                schema: "Correspondencia",
                table: "HRDetalleInstrucciones",
                column: "HRDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_HRDetalleInstrucciones_InstruccionId",
                schema: "Correspondencia",
                table: "HRDetalleInstrucciones",
                column: "InstruccionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HRDetalleInstrucciones",
                schema: "Correspondencia");

            migrationBuilder.DropTable(
                name: "HojaRutaDetalle",
                schema: "Correspondencia");
        }
    }
}
