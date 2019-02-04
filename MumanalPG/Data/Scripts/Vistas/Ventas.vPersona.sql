DROP VIEW "Ventas"."vPersona";

CREATE OR REPLACE VIEW "Ventas"."vPersona" AS
SELECT "IdBeneficiario",
    "DocumentoIdentidad",
    "Denominacion"
from "RRHH"."Beneficiario";

ALTER TABLE "Ventas"."vPersona" OWNER TO postgres;

select * from "Ventas"."vPersona";
--select * from "RRHH"."Beneficiario";
