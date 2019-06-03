using Microsoft.EntityFrameworkCore.Migrations;

namespace MumanalPG.Data.Migrations
{
    public partial class StoreProcedureDocumentosCorrelativo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            const string c = "\"";
            var sp = $@"CREATE OR REPLACE FUNCTION {c}Correspondencia{c}.{c}llenar_correletativo{c}() RETURNS TRIGGER AS $llenar_correletativo$
            DECLARE
                v_year int; 
            v_max_correlativo int; 
            BEGIN
   
            v_year:= EXTRACT(YEAR FROM NEW.{c}Fecha{c});
            SELECT MAX({c}Correspondencia{c}.{c}Documentos{c}.{c}Correlativo{c}) into v_max_correlativo 
            FROM {c}Correspondencia{c}.{c}Documentos{c} 
            WHERE {c}Correspondencia{c}.{c}Documentos{c}.{c}Gestion{c} = v_year
            AND {c}Correspondencia{c}.{c}Documentos{c}.{c}TipoId{c}= NEW.{c}TipoId{c}
            AND {c}Correspondencia{c}.{c}Documentos{c}.{c}AreaFuncionarioOrigen{c} = NEW.{c}AreaFuncionarioOrigen{c};
	 
            IF v_max_correlativo IS NULL THEN
            v_max_correlativo := 0;
            END IF;
   
            NEW.{c}Correlativo{c} := v_max_correlativo+1;
            NEW.{c}Gestion{c} := v_year;
            NEW.{c}Cite{c} := NEW.{c}Cite{c} || '  ' || NEW.{c}Correlativo{c} || '/' || NEW.{c}Gestion{c};
  
            RETURN NEW;
            END;
                $llenar_correletativo$ LANGUAGE plpgsql;

            DROP TRIGGER IF EXISTS llenar_correletativo on {c}Correspondencia{c}.{c}Documentos{c};

            CREATE TRIGGER llenar_correletativo BEFORE INSERT
                ON {c}Correspondencia{c}.{c}Documentos{c} FOR EACH ROW 
                EXECUTE PROCEDURE {c}Correspondencia{c}.{c}llenar_correletativo{c}();";
            
            migrationBuilder.Sql(sp);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
