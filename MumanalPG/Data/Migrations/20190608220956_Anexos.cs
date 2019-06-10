using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class Anexos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HojaRutaDocumentos",
                schema: "Planificacion");
            
            migrationBuilder.CreateTable(
                name: "TiposAnexo",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    IdEstadoRegistro = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposAnexo", x => x.Id);
                });

           
            migrationBuilder.CreateTable(
                name: "Anexos",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Descripcion = table.Column<string>(maxLength: 200, nullable: true),
                    PathArchivo = table.Column<string>(nullable: true),
                    TipoId = table.Column<int>(nullable: false),
                    HRDetalleId = table.Column<int>(nullable: false),
                    IdEstadoRegistro = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Anexos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Anexos_HojaRutaDetalle_HRDetalleId",
                        column: x => x.HRDetalleId,
                        principalSchema: "Correspondencia",
                        principalTable: "HojaRutaDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Anexos_TiposAnexo_TipoId",
                        column: x => x.TipoId,
                        principalSchema: "Correspondencia",
                        principalTable: "TiposAnexo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_HRDetalleId",
                schema: "Correspondencia",
                table: "Anexos",
                column: "HRDetalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Anexos_TipoId",
                schema: "Correspondencia",
                table: "Anexos",
                column: "TipoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Anexos",
                schema: "Correspondencia");

            migrationBuilder.DropTable(
                name: "TiposAnexo",
                schema: "Correspondencia");
        }
    }
}
