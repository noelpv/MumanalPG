using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class AddlAdtChangedPasswordToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "LastChangedPassword",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastChangedPassword",
                table: "AspNetUsers");
        }
    }
}
