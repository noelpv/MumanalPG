DROP FUNCTION "Ventas"."pVerificaLimite"(integer);
 
CREATE OR REPLACE FUNCTION "Ventas"."pVerificaLimite"(IdUnidadEjecutora INTeger)
 RETURNS TABLE (
 --"IdUnidadEjecutora" int4,
 MontoLimite money,
 CantidadLimite INT2
) 
AS $$
begin
 	RETURN QUERY 
 	select "MontoLimite", "CantidadLimite" from "RRHH"."UnidadEjecutora" where "IdUnidadEjecutora" = IdUnidadEjecutora;
end;
$$ 
LANGUAGE 'plpgsql';
	

SELECT * FROM "Ventas"."pVerificaLimite"(22);