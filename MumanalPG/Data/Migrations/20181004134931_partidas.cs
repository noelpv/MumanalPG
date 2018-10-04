using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class partidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "FinanzasParam");

            migrationBuilder.CreateTable(
                name: "Partida",
                schema: "FinanzasParam",
                columns: table => new
                {
                    IdPartida = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdSubGrupo = table.Column<short>(nullable: false),
                    Descripcion = table.Column<string>(nullable: true),
                    Gestion = table.Column<int>(nullable: false),
                    VidaUtil = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partida", x => x.IdPartida);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Partida",
                schema: "FinanzasParam");
        }
    }
}
