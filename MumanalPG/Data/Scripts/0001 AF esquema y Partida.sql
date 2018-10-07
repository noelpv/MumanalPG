/*
CREATE SCHEMA "Administra" AUTHORIZATION postgres;
CREATE SCHEMA "Contable" AUTHORIZATION postgres;
CREATE SCHEMA "Finanzas" AUTHORIZATION postgres;
CREATE SCHEMA "Generales" AUTHORIZATION postgres;
CREATE SCHEMA "Planificacion" AUTHORIZATION postgres;
CREATE SCHEMA "RRHH" AUTHORIZATION postgres;
CREATE SCHEMA "Ventas" AUTHORIZATION postgres;

CREATE SCHEMA "AdministraParam" AUTHORIZATION postgres;
CREATE SCHEMA "ContableParam" AUTHORIZATION postgres;
CREATE SCHEMA "FinanzasParam" AUTHORIZATION postgres;
CREATE SCHEMA "GeneralesParam" AUTHORIZATION postgres;
CREATE SCHEMA "PlanificacionParam" AUTHORIZATION postgres;
CREATE SCHEMA "RRHHParam" AUTHORIZATION postgres;
CREATE SCHEMA "VentasParam" AUTHORIZATION postgres;



CREATE TABLE "FinanzasParam"."Partida" (
    "IdPartida" integer NOT NULL,
    "IdSubGrupo" integer NOT NULL,
    "Descripcion" character varying,
    "Gestion" integer,
    "VidaUtil" smallint
);

ALTER TABLE "FinanzasParam"."Partida" OWNER TO postgres;

CREATE SEQUENCE "FinanzasParam"."Partida_IdPartida_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER TABLE "FinanzasParam"."Partida_IdPartida_seq" OWNER TO postgres;
ALTER SEQUENCE "FinanzasParam"."Partida_IdPartida_seq" OWNED BY "FinanzasParam"."Partida"."IdPartida";
ALTER TABLE ONLY "FinanzasParam"."Partida" ALTER COLUMN "IdPartida" SET DEFAULT nextval('"FinanzasParam"."Partida_IdPartida_seq"'::regclass);
SELECT pg_catalog.setval('"FinanzasParam"."Partida_IdPartida_seq"', 1, false);

ALTER TABLE ONLY "FinanzasParam"."Partida" ADD CONSTRAINT "Partida_pkey" PRIMARY KEY ("IdPartida");

----------------------------------------------------------------------------------------------

CREATE TABLE "AdministraParam"."Grupo" (
    "IdGrupo" integer NOT NULL,
    "Descripcion" character varying
);

ALTER TABLE "AdministraParam"."Grupo" OWNER TO postgres;

CREATE SEQUENCE "AdministraParam"."Grupo_IdGrupo_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;

ALTER TABLE "AdministraParam"."Grupo_IdGrupo_seq" OWNER TO postgres;
ALTER SEQUENCE "AdministraParam"."Grupo_IdGrupo_seq" OWNED BY "AdministraParam"."Grupo"."IdGrupo";
ALTER TABLE ONLY "AdministraParam"."Grupo" ALTER COLUMN "IdGrupo" SET DEFAULT nextval('"AdministraParam"."Grupo_IdGrupo_seq"'::regclass);
SELECT pg_catalog.setval('"AdministraParam"."Grupo_IdGrupo_seq"', 1, false);

ALTER TABLE ONLY "AdministraParam"."Grupo" ADD CONSTRAINT "Grupo_pkey" PRIMARY KEY ("IdGrupo");

----------------------------------------------------------------------------------------------

