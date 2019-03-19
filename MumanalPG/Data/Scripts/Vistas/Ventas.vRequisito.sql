drop view "Ventas"."vRequisito";

CREATE OR REPLACE VIEW "Ventas"."vRequisito" AS
select "IdVentaRequisito", "IdVentaContratacion", "Descripcion", "PathArchivo", "ArchivoCargado", "EsObligatorio", "Orden"
from "Ventas"."VentaRequisito" R
inner join "Ventas"."DocumentoRespaldo" L on R."IdDocumentoRespaldo" = L."IdDocumentoRespaldo";

ALTER TABLE "Ventas"."vRequisito" OWNER TO postgres;

select * from "Ventas"."vRequisito";