using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class AddCorrelativeToHR : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CorrelativoUE",
                schema: "Correspondencia",
                table: "HojaRuta",
                nullable: true);
            migrationBuilder.AddColumn<string>(
                name: "CiteUE",
                schema: "Correspondencia",
                table: "HojaRuta",
                maxLength: 50,
                nullable: true);
            
            const string c = "\"";
            var sp = $@"CREATE OR REPLACE FUNCTION {c}Correspondencia{c}.{c}generar_correletativo_ue_hr{c}() RETURNS TRIGGER AS $generar_correletativo_ue_hr$
            DECLARE
                v_year int; 
                v_max_correlativo int; 
            BEGIN
   
            v_year:= EXTRACT(YEAR FROM NEW.{c}FechaRegistro{c});
            SELECT MAX({c}Correspondencia{c}.{c}HojaRuta{c}.{c}CorrelativoUE{c}) into v_max_correlativo 
            FROM {c}Correspondencia{c}.{c}HojaRuta{c} 
            WHERE {c}Correspondencia{c}.{c}HojaRuta{c}.{c}Gestion{c} = v_year
            AND {c}Correspondencia{c}.{c}HojaRuta{c}.{c}TipoHojaRuta{c}= NEW.{c}TipoHojaRuta{c}
            AND {c}Correspondencia{c}.{c}HojaRuta{c}.{c}UnidadEjecutoraId{c} = NEW.{c}UnidadEjecutoraId{c};
	 
            IF v_max_correlativo IS NULL THEN
             v_max_correlativo := 0;
            END IF;
   
            NEW.{c}CorrelativoUE{c} := v_max_correlativo+1;
            NEW.{c}CiteUE{c} := NEW.{c}CiteUE{c} || '   ' || NEW.{c}CorrelativoUE{c} || '/' || v_year;
  
            RETURN NEW;
            END;
                $generar_correletativo_ue_hr$ LANGUAGE plpgsql;

            DROP TRIGGER IF EXISTS generar_correletativo_ue_hr on {c}Correspondencia{c}.{c}HojaRuta{c};

            CREATE TRIGGER generar_correletativo_ue_hr BEFORE INSERT
                ON {c}Correspondencia{c}.{c}HojaRuta{c} FOR EACH ROW 
                EXECUTE PROCEDURE {c}Correspondencia{c}.{c}generar_correletativo_ue_hr{c}();";
            
            migrationBuilder.Sql(sp);

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CorrelativoUE",
                schema: "Correspondencia",
                table: "HojaRuta"
            );
            
            migrationBuilder.DropColumn(
                name: "CiteUE",
                schema: "Correspondencia",
                table: "HojaRuta"
            );
            
            migrationBuilder.DropColumn(
                name: "NombreUE",
                schema: "Correspondencia",
                table: "HojaRuta"
            );

        }
    }
}
