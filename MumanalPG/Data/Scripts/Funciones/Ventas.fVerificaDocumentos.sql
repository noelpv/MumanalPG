DROP FUNCTION "Ventas"."fVerificaDocumentos"(integer);

-- 0 = 'Aun no se han generado los requisitos!!!'
-- 1 = 'Todos los Documentos fueron cargados!!!'
-- 2 = 'Falta cargar documentos!!!'

CREATE OR REPLACE FUNCTION "Ventas"."fVerificaDocumentos"(IdVentaContratacion INTeger)
RETURNS TABLE (
 Entero INT
) 
AS $$
begin
	return query
	select case when A."obligatorio" = 0 then 0
							when A."obligatorio" > 0 and A."obligatorio" = A."cargado" then 1
							else 2 end as Entero
	from (
		select coalesce(sum(case when "EsObligatorio"  = TRUE then 1 else 0 end), 0) as obligatorio,
					coalesce(sum(case when "ArchivoCargado" = TRUE then 1 else 0 end), 0) as cargado
		from "Ventas"."VentaRequisito" R
		inner join "Ventas"."DocumentoRespaldo" DR on R."IdDocumentoRespaldo" = DR."IdDocumentoRespaldo"
		where "IdVentaContratacion" = IdVentaContratacion
		and DR."EsObligatorio" = TRUE
	) A;
end;
$$ 
LANGUAGE 'plpgsql';
	

SELECT * FROM "Ventas"."fVerificaDocumentos"(22);

SELECT * FROM "Ventas"."VentaRequisito" where "IdVentaContratacion" = (22);





