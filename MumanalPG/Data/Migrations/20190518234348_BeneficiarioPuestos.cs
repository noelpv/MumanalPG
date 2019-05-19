using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class BeneficiarioPuestos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Puesto",
                schema: "RRHH");
            
            migrationBuilder.AddColumn<int>(
                name: "PuestoId",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "Puesto",
                schema: "RRHH",
                columns: table => new
                {
                    IdPuesto = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdUnidadEjecutora = table.Column<int>(nullable: false),
                    Gestion = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Sigla = table.Column<string>(nullable: true),
                    IdCargo = table.Column<int>(nullable: false, defaultValue: 0),
                    Item = table.Column<int>(nullable: false, defaultValue:0),
                    Vacante = table.Column<bool>(nullable: false, defaultValue: true),
                    IdDepartamento = table.Column<int>(nullable: false),
                    EsDePlanilla = table.Column<bool>(nullable: false, defaultValue: false),
                    IdEstadoRegistro = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql:"now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puesto", x => x.IdPuesto);
                    table.ForeignKey(
                        name: "FK_Puesto_UnidadEjecutora_IdUnidadEjecutora",
                        column: x => x.IdUnidadEjecutora,
                        principalSchema: "RRHH",
                        principalTable: "UnidadEjecutora",
                        principalColumn: "IdUnidadEjecutora",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Puesto_IdUnidadEjecutora",
                schema: "RRHH",
                table: "Puesto",
                column: "IdUnidadEjecutora");
            
            migrationBuilder.InsertData(
                table: "UnidadEjecutora",
                schema: "RRHH",
                columns: new[] {"IdUnidadEjecutora", "Descripcion"},
                values: new object[] {1,"NO ESPECIFICADO"});
            
            migrationBuilder.InsertData(
                table: "Puesto",
                schema: "RRHH",
                columns: new[] {"IdUnidadEjecutora", "Descripcion", "IdDepartamento", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {1,"NO ESPECIFICADO", 2,0,1});

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiario_Puesto_PuestoId",
                schema: "RRHH",
                table: "Beneficiario",
                column: "PuestoId",
                principalSchema: "RRHH",
                principalTable: "Puesto",
                principalColumn: "IdPuesto",
                onDelete: ReferentialAction.Cascade);
            
            migrationBuilder.CreateIndex(
                name: "IX_Beneficiario_PuestoId",
                schema: "RRHH",
                table: "Beneficiario",
                column: "PuestoId",
                unique: false);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiario_Puesto_PuestoId",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropTable(
                name: "Puesto",
                schema: "RRHH");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiario_PuestoId",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropColumn(
                name: "PuestoId",
                schema: "RRHH",
                table: "Beneficiario");
        }
    }
}
