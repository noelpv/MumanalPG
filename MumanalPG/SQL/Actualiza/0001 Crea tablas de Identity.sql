

CREATE TABLE public."AspNetRoleClaims" (
    "Id" integer NOT NULL,
    "RoleId" character varying(450),
    "ClaimType" character varying,
    "ClaimValue" character varying
);


ALTER TABLE public."AspNetRoleClaims" OWNER TO postgres;


CREATE SEQUENCE public."AspNetRoleClaims_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."AspNetRoleClaims_Id_seq" OWNER TO postgres;


ALTER SEQUENCE public."AspNetRoleClaims_Id_seq" OWNED BY public."AspNetRoleClaims"."Id";

CREATE TABLE public."AspNetRoles" (
    "Id" character varying(450) NOT NULL,
    "Name" character varying(256),
    "NormalizedName" character varying(256),
    "ConcurrencyStamp" character varying
);


ALTER TABLE public."AspNetRoles" OWNER TO postgres;


CREATE TABLE public."AspNetUserClaims" (
    "Id" integer NOT NULL,
    "UserId" character varying(450),
    "ClaimType" character varying,
    "ClaimValue" character varying
);


ALTER TABLE public."AspNetUserClaims" OWNER TO postgres;


CREATE SEQUENCE public."AspNetUserClaims_Id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER TABLE public."AspNetUserClaims_Id_seq" OWNER TO postgres;


ALTER SEQUENCE public."AspNetUserClaims_Id_seq" OWNED BY public."AspNetUserClaims"."Id";



CREATE TABLE public."AspNetUserLogins" (
    "LoginProvider" character varying(128) NOT NULL,
    "ProviderKey" character varying(128) NOT NULL,
    "ProviderDisplayName" character varying,
    "UserId" character varying(450)
);


ALTER TABLE public."AspNetUserLogins" OWNER TO postgres;


CREATE TABLE public."AspNetUserRoles" (
    "UserId" character varying(450) NOT NULL,
    "RoleId" character varying(450) NOT NULL
);


ALTER TABLE public."AspNetUserRoles" OWNER TO postgres;


CREATE TABLE public."AspNetUserTokens" (
    "UserId" character varying(450) NOT NULL,
    "LoginProvider" character varying(128) NOT NULL,
    "Name" character varying(128) NOT NULL,
    "Value" character varying
);


ALTER TABLE public."AspNetUserTokens" OWNER TO postgres;


CREATE TABLE public."AspNetUsers" (
    "Id" character varying(450) NOT NULL,
    "UserName" character varying(256),
    "NormalizedUserName" character varying(256),
    "Email" character varying(256),
    "NormalizedEmail" character varying(256),
    "EmailConfirmed" boolean,
    "PasswordHash" character varying,
    "SecurityStamp" character varying,
    "ConcurrencyStamp" character varying,
    "PhoneNumber" character varying,
    "PhoneNumberConfirmed" boolean,
    "TwoFactorEnabled" boolean,
    "LockoutEnd" timestamp with time zone,
    "LockoutEnabled" boolean,
    "AccessFailedCount" integer
);


ALTER TABLE public."AspNetUsers" OWNER TO postgres;


CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

ALTER TABLE ONLY public."AspNetRoleClaims" ALTER COLUMN "Id" SET DEFAULT nextval('public."AspNetRoleClaims_Id_seq"'::regclass);
ALTER TABLE ONLY public."AspNetUserClaims" ALTER COLUMN "Id" SET DEFAULT nextval('public."AspNetUserClaims_Id_seq"'::regclass);


SELECT pg_catalog.setval('public."AspNetRoleClaims_Id_seq"', 1, false);


SELECT pg_catalog.setval('public."AspNetUserClaims_Id_seq"', 1, false);

-----
ALTER TABLE ONLY public."AspNetRoleClaims"		ADD CONSTRAINT "AspNetRoleClaims_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."AspNetRoles"			ADD CONSTRAINT "AspNetRoles_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."AspNetUserClaims"		ADD CONSTRAINT "AspNetUserClaims_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."AspNetUserLogins"		ADD CONSTRAINT "AspNetUserLogins_pkey" PRIMARY KEY ("LoginProvider", "ProviderKey");
ALTER TABLE ONLY public."AspNetUserRoles"		ADD CONSTRAINT "AspNetUserRoles_pkey" PRIMARY KEY ("UserId", "RoleId");
ALTER TABLE ONLY public."AspNetUserTokens"		ADD CONSTRAINT "AspNetUserTokens_pkey" PRIMARY KEY ("UserId", "LoginProvider", "Name");
ALTER TABLE ONLY public."AspNetUsers"			ADD CONSTRAINT "AspNetUsers_pkey" PRIMARY KEY ("Id");
ALTER TABLE ONLY public."__EFMigrationsHistory" ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");

