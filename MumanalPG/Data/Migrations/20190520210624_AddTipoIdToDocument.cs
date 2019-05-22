using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class AddTipoIdToDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_TipoDocumento_TipoId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_TipoId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "TipoId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdMunicipio",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoRegistro",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdEdificio",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumentoRespaldo",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "IdCalle",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: true,
                oldClrType: typeof(DateTime));

           migrationBuilder.AddColumn<short>(
                name: "TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "TipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_TipoDocumento_TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "TipoId",
                principalSchema: "Correspondencia",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdMunicipio",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEstadoRegistro",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdEdificio",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdDocumentoRespaldo",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IdCalle",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistro",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                schema: "RRHH",
                table: "Beneficiario",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

        }
    }
}
