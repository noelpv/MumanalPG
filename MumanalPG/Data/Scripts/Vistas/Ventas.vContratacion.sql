DROP VIEW "Ventas"."vContratacion";

CREATE OR REPLACE VIEW "Ventas"."vContratacion" AS
SELECT a."IdVentaContratacion",
    a."Gestion",
    u."Sigla" AS "UnidadEjecutora",
    a."CorrelativoUnidad",
    a."FechaVenta",
    b."Denominacion" AS "Beneficiario",
    c."Denominacion" AS "Garante",
    a."IdAsrSiver",
		ER."Descripcion" as "Estado"
FROM "Ventas"."VentaContratacion" a
JOIN "RRHH"."Beneficiario" b ON a."IdBeneficiario" = b."IdBeneficiario"
JOIN "RRHH"."Beneficiario" c ON a."IdBeneficiarioGarante" = c."IdBeneficiario"
JOIN "RRHH"."UnidadEjecutora" u ON a."IdUnidadEjecutora" = u."IdUnidadEjecutora"
join "Ventas"."EstadoRegistro" ER on A."IdEstadoRegistro" = ER."IdEstadoRegistro";
  
ALTER TABLE "Ventas"."vContratacion" OWNER TO postgres;

select * from "Ventas"."vContratacion";
select * from "Ventas"."VentaContratacion";
