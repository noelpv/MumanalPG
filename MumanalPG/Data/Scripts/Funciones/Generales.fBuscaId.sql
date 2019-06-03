DROP FUNCTION "Generales"."fBuscaId"(varchar(100));

CREATE OR REPLACE FUNCTION "Generales"."fBuscaId"("id" varchar)
  RETURNS TABLE("idunidadejecutora" int4) AS $$
begin
 	RETURN QUERY 
 	SELECT "IdUnidadEjecutora"
	from "Seguridad"."UsuarioUnidadEjecutora" E
	inner join "AspNetUsers" U on E."IdUsuario" = U."IdUsuario"
  where "Id" = Id;
end;
$$
LANGUAGE plpgsql;

SELECT * FROM "Generales"."fBuscaId"('23157b87-10db-4118-a711-3f94d8f5e13e');
