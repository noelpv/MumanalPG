using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class GenerarCorrelativoHojaRuta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            var sp = $@"CREATE OR REPLACE FUNCTION {c}Correspondencia{c}.{c}generar_correletativo_hr{c}() RETURNS TRIGGER AS $generar_correletativo_hr$
            DECLARE
                v_year int; 
                v_max_correlativo int; 
            BEGIN
   
            v_year:= EXTRACT(YEAR FROM NEW.{c}FechaRegistro{c});
            SELECT MAX({c}Correspondencia{c}.{c}HojaRuta{c}.{c}SolicitudCodigo{c}) into v_max_correlativo 
            FROM {c}Correspondencia{c}.{c}HojaRuta{c} 
            WHERE {c}Correspondencia{c}.{c}HojaRuta{c}.{c}Gestion{c} = v_year
            AND {c}Correspondencia{c}.{c}HojaRuta{c}.{c}TipoHojaRuta{c}= NEW.{c}TipoHojaRuta{c};
	 
            IF v_max_correlativo IS NULL THEN
             v_max_correlativo := 0;
            END IF;
   
            NEW.{c}SolicitudCodigo{c} := v_max_correlativo+1;
            NEW.{c}Gestion{c} := v_year;
            NEW.{c}CiteHojaRuta{c} := NEW.{c}CiteHojaRuta{c} || '   ' || NEW.{c}SolicitudCodigo{c} || '/' || NEW.{c}Gestion{c};
  
            RETURN NEW;
            END;
                $generar_correletativo_hr$ LANGUAGE plpgsql;

            DROP TRIGGER IF EXISTS generar_correletativo_hr on {c}Correspondencia{c}.{c}HojaRuta{c};

            CREATE TRIGGER generar_correletativo_hr BEFORE INSERT
                ON {c}Correspondencia{c}.{c}HojaRuta{c} FOR EACH ROW 
                EXECUTE PROCEDURE {c}Correspondencia{c}.{c}generar_correletativo_hr{c}();";
            
            migrationBuilder.Sql(sp);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
