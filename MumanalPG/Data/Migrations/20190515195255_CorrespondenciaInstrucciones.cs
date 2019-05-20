using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class CorrespondenciaInstrucciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrucciones",
                schema: "Planificacion");
            
            migrationBuilder.EnsureSchema(
                name: "Correspondencia");
            
            migrationBuilder.CreateTable(
                name: "Instrucciones",
                schema: "Correspondencia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: true),
                    IdEstadoRegistro = table.Column<int>(nullable: false, defaultValue: 0),
                    IdUsuario = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrucciones", x => x.Id);
                });

            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Preparar Informe", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Preparar Respuesta para mi firma", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Elaborar Resolución", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Proceder según lo establecido", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Hacer seguimiento", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Para su conocimiento", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Archivar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Aprobar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Complementar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Corregir", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Revisar o Evaluar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Remitir a ", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Informar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Procesar", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Reunión en mi despacho", "-",0,1});
            
            migrationBuilder.InsertData(
                table: "Instrucciones",
                schema: "Correspondencia",
                columns: new[] {"Nombre", "Descripcion", "IdEstadoRegistro", "IdUsuario"},
                values: new object[] {"Coordinar con", "-",0,1});
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Instrucciones",
                schema: "Correspondencia");
        }
    }
}
