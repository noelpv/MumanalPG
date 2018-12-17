
-- DROP VIEW "Ventas"."vContratacion";
/*
CREATE OR REPLACE VIEW "Ventas"."vContratacion" AS
 SELECT a."IdVentaContratacion",
    a."Gestion",
    u."Sigla" AS "UnidadEjecutora",
    a."CorrelativoUnidad",
    a."FechaVenta",
    b."Denominacion" AS "Beneficiario",
    c."Denominacion" AS "Garante",
    a."IdAsrSiver"
   FROM "Ventas"."VentaContratacion" a
     JOIN "Ventas"."Beneficiario" b ON a."IdBeneficiario" = b."IdBeneficiario"
     JOIN "Ventas"."Beneficiario" c ON a."IdBeneficiarioGarante" = c."IdBeneficiario"
     JOIN "Ventas"."UnidadEjecutora" u ON a."IdUnidadEjecutora" = u."IdUnidadEjecutora";

ALTER TABLE "Ventas"."vContratacion" OWNER TO postgres;
------------------------------------------

CREATE OR REPLACE VIEW "Ventas"."vRequisito" AS
select "IdVentaRequisito", "IdVentaContratacion", "Descripcion", "DocumentoEntregado", "PathArchivo", "ArchivoCargado"
from "Ventas"."VentaRequisito" R
inner join "Ventas"."DocumentoRespaldo" L on R."IdDocumentoRespaldo" = L."IdDocumentoRespaldo";

ALTER TABLE "Ventas"."vRequisito" OWNER TO postgres;
*/