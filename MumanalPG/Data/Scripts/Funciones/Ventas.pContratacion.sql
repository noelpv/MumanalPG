DROP FUNCTION "Ventas"."pContratacion"(text);
 
CREATE OR REPLACE FUNCTION "Ventas"."pContratacion"(IdAspUser text)
 RETURNS TABLE (
		IdVentaContratacion int4,
    Gestion varchar(4),
    UnidadEjecutora varchar(20),
    CorrelativoUnidad int4,
    FechaVenta timestamp,
    Beneficiario varchar(100),
    Garante varchar(100),
    IdAsrSiver varchar(20)
) 
AS $$
begin
 	RETURN QUERY 
 	SELECT a."IdVentaContratacion",
    a."Gestion",
    u."Sigla" AS "UnidadEjecutora",
    a."CorrelativoUnidad",
    a."FechaVenta",
    b."Denominacion" AS "Beneficiario",
    c."Denominacion" AS "Garante",
    a."IdAsrSiver"
	FROM "Ventas"."VentaContratacion" a
	JOIN "RRHH"."Beneficiario" b ON a."IdBeneficiario" = b."IdBeneficiario"
	JOIN "RRHH"."Beneficiario" c ON a."IdBeneficiarioGarante" = c."IdBeneficiario"
	JOIN "RRHH"."UnidadEjecutora" u ON a."IdUnidadEjecutora" = u."IdUnidadEjecutora"
	join "Seguridad"."UsuarioUnidadEjecutora" R on u."IdUnidadEjecutora" = R."IdUnidadEjecutora"
	join "AspNetUsers" S on S."IdUsuario" = R."IdUsuario"
  where S."Id" = IdAspUser;
end;
$$ 
LANGUAGE 'plpgsql';

SELECT * FROM "Ventas"."pContratacion"('0eb3655e-dc53-4950-9414-455d8d1329be');