
CREATE TABLE public."Activo" (
    "ActivoId" integer NOT NULL,
    "Codigo" character varying(40),
    "Descripcion" character varying(500)
);


ALTER TABLE public."Activo" OWNER TO postgres;

CREATE SEQUENCE public."Activo_ActivoId_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."Activo_ActivoId_seq" OWNER TO postgres;

ALTER SEQUENCE public."Activo_ActivoId_seq" OWNED BY public."Activo"."ActivoId";

ALTER TABLE ONLY public."Activo" ALTER COLUMN "ActivoId" SET DEFAULT nextval('public."Activo_ActivoId_seq"'::regclass);
SELECT pg_catalog.setval('public."Activo_ActivoId_seq"', 1, true);
ALTER TABLE ONLY public."Activo"				ADD CONSTRAINT "Activo_pkey" PRIMARY KEY ("ActivoId");
