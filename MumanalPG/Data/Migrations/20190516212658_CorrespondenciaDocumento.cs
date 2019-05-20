using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class CorrespondenciaDocumento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    TipoId = table.Column<short>(nullable: false),
                    Correlativo = table.Column<int>(nullable: false),
                    Gestion = table.Column<int>(nullable: false),
                    Cite = table.Column<string>(maxLength: 50, nullable: false),
                    FuncionarioOrigenId = table.Column<int>(nullable: false),
                    FuncionarioDestinoId = table.Column<int>(nullable: false),
                    FuncionarioViaId = table.Column<int>(nullable: false),
                    FuncionarioCCId = table.Column<int>(nullable: false),
                    CargoFuncionarioOrigen = table.Column<string>(maxLength: 50, nullable: false),
                    CargoFuncionarioDestino = table.Column<string>(maxLength: 50, nullable: false),
                    CargoFuncionarioVia = table.Column<string>(maxLength: 50, nullable: true),
                    CargoFuncionarioCC = table.Column<string>(maxLength: 50, nullable: true),
                    AreaFuncionarioOrigen = table.Column<string>(maxLength: 50, nullable: false),
                    AreaFuncionarioDestino = table.Column<string>(maxLength: 50, nullable: false),
                    AreaFuncionarioVia = table.Column<string>(maxLength: 50, nullable: true),
                    AreaFuncionarioCC = table.Column<string>(maxLength: 50, nullable: true),
                    Referencia = table.Column<string>(maxLength: 100, nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Contenido = table.Column<string>(type: "text", nullable: false),
                    IdEstadoRegistro = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_Beneficiario_FuncionarioCCId",
                        column: x => x.FuncionarioCCId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_Beneficiario_FuncionarioDestinoId",
                        column: x => x.FuncionarioDestinoId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_Beneficiario_FuncionarioOrigenId",
                        column: x => x.FuncionarioOrigenId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_Beneficiario_FuncionarioViaId",
                        column: x => x.FuncionarioViaId,
                        principalSchema: "RRHH",
                        principalTable: "Beneficiario",
                        principalColumn: "IdBeneficiario",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_TipoDocumento_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "Correspondencia",
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioCCId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioDestinoId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioOrigenId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioOrigenId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioViaId");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos",
                schema: "Correspondencia");
        }
    }
}
