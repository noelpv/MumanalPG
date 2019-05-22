using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class ModifyDocumentsRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Beneficiario_FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_Beneficiario_FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos");
            
            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldNullable: false);
            
            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                defaultValue: -1,
                oldClrType: typeof(int),
                oldNullable: false);
            
            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioViaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Beneficiario_FuncionarioViaId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioViaId",
                principalSchema: "RRHH",
                principalTable: "Beneficiario",
                principalColumn: "IdBeneficiario",
                onDelete: ReferentialAction.Restrict);
            
            migrationBuilder.CreateIndex(
                name: "IX_Documentos_FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioCCId");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_Beneficiario_FuncionarioCCId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "FuncionarioCCId",
                principalSchema: "RRHH",
                principalTable: "Beneficiario",
                principalColumn: "IdBeneficiario",
                onDelete: ReferentialAction.Restrict);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
