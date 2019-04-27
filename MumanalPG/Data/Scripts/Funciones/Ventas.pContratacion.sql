-- Ventas."VentaContratacion"."IdEstadoRegistro":
-- 1. Registrado
-- 2. Enviado
-- 3. 
--DROP FUNCTION "Ventas"."pContratacion"(text);
 
CREATE OR REPLACE FUNCTION "Ventas"."pContratacion"(IdAspUser text, searchString TEXT)
 RETURNS TABLE (
		IdVentaContratacion int4,
    Gestion varchar(4),
    UnidadEjecutora varchar(20),
    CorrelativoUnidad int4,
    FechaVenta timestamp,
    Beneficiario varchar(100),
    Garante varchar(100),
    IdAsrSiver varchar(20),
		Estado varchar(20)
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
    a."IdAsrSiver",
		ER."Descripcion" as Estado
	FROM "Ventas"."VentaContratacion" a
	JOIN "RRHH"."Beneficiario" b ON a."IdBeneficiario" = b."IdBeneficiario"
	JOIN "RRHH"."Beneficiario" c ON a."IdBeneficiarioGarante" = c."IdBeneficiario"
	JOIN "RRHH"."UnidadEjecutora" u ON a."IdUnidadEjecutora" = u."IdUnidadEjecutora"
	join "Seguridad"."UsuarioUnidadEjecutora" R on u."IdUnidadEjecutora" = R."IdUnidadEjecutora"
	join "AspNetUsers" S on S."IdUsuario" = R."IdUsuario"
	join "AspNetUserRoles" UR on S."Id" = UR."UserId"
	join "Seguridad"."RoleEstadoRegistro" RER on UR."RoleId" = RER."IdRole" and A."IdEstadoRegistro" = RER."IdEstadoRegistro"
	join "Ventas"."EstadoRegistro" ER on A."IdEstadoRegistro" = ER."IdEstadoRegistro"
  where S."Id" = IdAspUser
	and (b."PrimerApellido" like searchString || '%' or a."IdAsrSiver" = searchString or searchString = '')
	order by "IdVentaContratacion" desc;
end;
$$
LANGUAGE 'plpgsql';

SELECT * FROM "Ventas"."pContratacion"('23157b87-10db-4118-a711-3f94d8f5e13e', 'AREVALO');