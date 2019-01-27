CREATE or REPLACE PROCEDURE "Ventas"."pGeneraRequisitos"(IdVentaContratacion INTeger)
LANGUAGE SQL
AS $$
    INSERT INTO "Ventas"."VentaRequisito" 
         ("IdVentaContratacion", "IdBeneficiario", "IdDocumentoRespaldo", "IdDocumentoFormato", "DocumentoEntregado", "PathArchivo", "ArchivoCargado", "Aprobado", "IdEstadoRegistro", "IdUsuario", "FechaRegistro")
    select IdVentaContratacion , 0               , "IdDocumentoRespaldo", 0                   , 'f'                 , ''           , 'f'             , 'f'       , 1                 , 1          , now()
    from "Ventas"."DocumentoRespaldo" D
    where D."EsUsadoComoRequisito" = 't'
    and not exists (select 1 from "Ventas"."VentaRequisito" R 
                    where R."IdVentaContratacion" = IdVentaContratacion and D."IdDocumentoRespaldo" = R."IdDocumentoRespaldo");
$$;

CALL "Ventas"."pGeneraRequisitos"(1);

select * from "Ventas"."VentaRequisito" where "IdVentaContratacion" = 1;