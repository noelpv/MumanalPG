using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class UsuarioBeneficiario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
          
            var sql = $@"UPDATE {c}RRHH{c}.{c}Beneficiario{c} SET {c}IdUsuario{c} = 0;";
            migrationBuilder.Sql(sql);
            
            sql = $"DELETE FROM {c}AspNetUsers{c} WHERE {c}UserName{c} LIKE '%@mumanal.org';";
            migrationBuilder.Sql(sql);
            
//            migrationBuilder.DropForeignKey(
//                name: "FK_AspNetUsers_Beneficiario_IdUsuario",
//                schema: "RRHH",
//                table: "Beneficiario");
            
//           migrationBuilder.DropIndex(
//                name: "IX_AspNetUsers_IdUsuario",
//                table: "AspNetUsers");
            
            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AddColumn<int>(
                name: "AspNetUserId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: -1);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_AspNetUserId",
                table: "AspNetUsers",
                column: "AspNetUserId",
                unique: false);

            migrationBuilder.AddForeignKey(
                name: "FK__AspNetUsers_Beneficiario_AspNetUserId",
                table: "AspNetUsers",
                column: "AspNetUserId",
                principalSchema: "RRHH",
                principalTable: "Beneficiario",
                principalColumn: "IdBeneficiario",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Beneficiario_AspNetUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_AspNetUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AspNetUserId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "IdUsuario",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
