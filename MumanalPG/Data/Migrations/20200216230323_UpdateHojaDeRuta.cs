using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class UpdateHojaDeRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EntidadExterna",
                schema: "Correspondencia",
                table: "HojaRuta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemitenteExterno",
                schema: "Correspondencia",
                table: "HojaRuta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EntidadExterna",
                schema: "Correspondencia",
                table: "HojaRuta");

            migrationBuilder.DropColumn(
                name: "RemitenteExterno",
                schema: "Correspondencia",
                table: "HojaRuta");
        }
    }
}
