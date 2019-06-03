using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class ModifyDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_TipoDocumento_TipoId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.AlterColumn<short>(
                name: "TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: false,
                oldClrType: typeof(short),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cite",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50);
            
            migrationBuilder.AlterColumn<string>(
                name: "Correlativo",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                oldClrType: typeof(int));
            
            migrationBuilder.AlterColumn<string>(
                name: "Gestion",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_TipoDocumento_TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                column: "TipoId",
                principalSchema: "Correspondencia",
                principalTable: "TipoDocumento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_TipoDocumento_TipoId",
                schema: "Correspondencia",
                table: "Documentos");

            migrationBuilder.AlterColumn<short>(
                name: "TipoId",
                schema: "Correspondencia",
                table: "Documentos",
                nullable: true,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<string>(
                name: "Cite",
                schema: "Correspondencia",
                table: "Documentos",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
