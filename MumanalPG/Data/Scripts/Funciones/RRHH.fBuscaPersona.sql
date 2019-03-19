DROP FUNCTION "RRHH"."fBuscaPersona"(varchar(100));
 
CREATE OR REPLACE FUNCTION "RRHH"."fBuscaPersona"(Busca varchar(100))
 RETURNS TABLE (
		IdBeneficiario int4,
    DocumentoIdentidad varchar(20),
    Denominacion varchar(100)
)
AS $$
begin
 	RETURN QUERY 
 	SELECT "IdBeneficiario", "DocumentoIdentidad", "Denominacion"
	from "RRHH"."Beneficiario"
  where "DocumentoIdentidad" like Busca || '%' or "Denominacion" like Busca || '%';
end;
$$ 
LANGUAGE 'plpgsql';

SELECT * FROM "RRHH"."fBuscaPersona"('-');