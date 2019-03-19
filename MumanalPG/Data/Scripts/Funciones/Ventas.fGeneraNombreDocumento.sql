DROP FUNCTION "Ventas"."fGeneraNombreDocumento"(integer);

CREATE OR REPLACE FUNCTION "Ventas"."fGeneraNombreDocumento"(IdVentaRequisito INTeger)
RETURNS TABLE (
 Cadena text
) 
AS $$
begin
	return query
	SELECT LPAD(C."IdAsrSiver"::text, 10, '0') || '-' || LPAD(R."IdDocumentoRespaldo"::text, 4, '0') || '.pdf' as Cadena
	FROM "Ventas"."VentaRequisito" R 
	inner join "Ventas"."VentaContratacion" C on R."IdVentaContratacion" = C."IdVentaContratacion"
	where R."IdVentaRequisito" = IdVentaRequisito;
end;
$$ 
LANGUAGE 'plpgsql';
	

SELECT * FROM "Ventas"."fGeneraNombreDocumento"(259);

/*SELECT LPAD(C."IdAsrSiver"::text, 10, '0') || '-' || LPAD(R."IdVentaRequisito"::text, 4, '0') || '.pdf' as Cadena
FROM "Ventas"."VentaRequisito" R 
inner join "Ventas"."VentaContratacion" C on R."IdVentaContratacion" = C."IdVentaContratacion"
where R."IdVentaRequisito" = (87);
*/
select * from "Ventas"."VentaRequisito"




