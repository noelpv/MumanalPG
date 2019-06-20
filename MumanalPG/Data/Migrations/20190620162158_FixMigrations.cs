using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace MumanalPG.Data.Migrations
{
    public partial class FixMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
//            migrationBuilder.AddColumn<string>(
//                name: "ApellidoCasada",
//                schema: "RRHH",
//                table: "Beneficiario",
//                nullable: true);
//
//            migrationBuilder.AddColumn<int>(
//                name: "IdBarrio",
//                schema: "RRHH",
//                table: "Beneficiario",
//                nullable: true);
//
//            migrationBuilder.AddColumn<int>(
//                name: "IdGenero",
//                schema: "RRHH",
//                table: "Beneficiario",
//                nullable: true);
//
//            migrationBuilder.AddColumn<string>(
//                name: "SegundoNombre",
//                schema: "RRHH",
//                table: "Beneficiario",
//                nullable: true);
//
//            migrationBuilder.AddColumn<string>(
//                name: "Descripcion",
//                schema: "Planificacion",
//                table: "PresupuestoGasto",
//                nullable: true);
//
//            migrationBuilder.CreateTable(
//                name: "Auxiliar",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdAuxiliar = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    NombreTabla = table.Column<string>(nullable: true),
//                    NombreCampoCodigo = table.Column<string>(nullable: true),
//                    NombreCampoDescripcion = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Auxiliar", x => x.IdAuxiliar);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "Banco",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdBanco = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Sigla = table.Column<string>(nullable: true),
//                    NIT = table.Column<string>(nullable: true),
//                    IdMunicipio = table.Column<int>(nullable: false),
//                    Direccion = table.Column<string>(nullable: true),
//                    Representante = table.Column<string>(nullable: true),
//                    CargoRepresentante = table.Column<string>(nullable: true),
//                    CodigoPostal = table.Column<string>(nullable: true),
//                    EsReservaFederal = table.Column<bool>(nullable: false),
//                    BancoIntermediario = table.Column<string>(nullable: true),
//                    Observaciones = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Banco", x => x.IdBanco);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "CuentaBancaria",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdCuentaBancaria = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdBanco = table.Column<int>(nullable: false),
//                    CuentaCodigo = table.Column<string>(nullable: true),
//                    Descripcion = table.Column<string>(nullable: true),
//                    IdTipoCuentaBanco = table.Column<int>(nullable: false),
//                    IdTipoMoneda = table.Column<int>(nullable: false),
//                    CodigoTgn = table.Column<string>(nullable: true),
//                    FechaApertura = table.Column<DateTime>(nullable: false),
//                    IdOrganismoFinanciador = table.Column<int>(nullable: false),
//                    FechaSaldoInicial = table.Column<DateTime>(nullable: false),
//                    SaldoInicialBs = table.Column<decimal>(nullable: false),
//                    SaldoInicialDolares = table.Column<decimal>(nullable: false),
//                    IngresosBs = table.Column<decimal>(nullable: false),
//                    IngresosDolares = table.Column<decimal>(nullable: false),
//                    EgresosBs = table.Column<decimal>(nullable: false),
//                    EgresosDolares = table.Column<decimal>(nullable: false),
//                    SaldoActualBs = table.Column<decimal>(nullable: false),
//                    SaldoActualDolares = table.Column<decimal>(nullable: false),
//                    CodigoSigep = table.Column<string>(nullable: true),
//                    EsCuentaUnica = table.Column<bool>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_CuentaBancaria", x => x.IdCuentaBancaria);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "Dosificacion",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdDosificacion = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdDocumentoRespaldo = table.Column<int>(nullable: false),
//                    NumeroAutorizacion = table.Column<string>(nullable: false),
//                    DosificacionFecha = table.Column<DateTime>(nullable: false),
//                    IdBeneficiario = table.Column<int>(nullable: false),
//                    IdBeneficiarioResponsable = table.Column<int>(nullable: false),
//                    CorrelativoInicial = table.Column<int>(nullable: false),
//                    CorrelativoFinal = table.Column<int>(nullable: false),
//                    CorrelativoFactura = table.Column<int>(nullable: false),
//                    FechaInicial = table.Column<DateTime>(nullable: false),
//                    FechaFinal = table.Column<DateTime>(nullable: false),
//                    FechaLimite = table.Column<DateTime>(nullable: false),
//                    DosificacionLlave = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Dosificacion", x => x.IdDosificacion);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "PlanCuentas",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdPlanCuentas = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Cuenta = table.Column<string>(nullable: true),
//                    SubCuenta1 = table.Column<string>(nullable: true),
//                    SubCuenta2 = table.Column<string>(nullable: true),
//                    NombreCuenta = table.Column<string>(nullable: true),
//                    IdAuxiliar1 = table.Column<int>(nullable: false),
//                    IdAuxiliar2 = table.Column<int>(nullable: false),
//                    IdAuxiliar3 = table.Column<int>(nullable: false),
//                    IdPlanCuentasPadre = table.Column<int>(nullable: false),
//                    EsDeMovimiento = table.Column<bool>(nullable: false),
//                    IdTipoCuenta = table.Column<int>(nullable: false),
//                    Nivel = table.Column<int>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_PlanCuentas", x => x.IdPlanCuentas);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "TipoCuentaBanco",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdTipoCuentaBanco = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_TipoCuentaBanco", x => x.IdTipoCuentaBanco);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "TipoMoneda",
//                schema: "Finanzas",
//                columns: table => new
//                {
//                    IdTipoMoneda = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Sigla = table.Column<string>(nullable: true),
//                    IdPais = table.Column<int>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_TipoMoneda", x => x.IdTipoMoneda);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "Continente",
//                schema: "Generales",
//                columns: table => new
//                {
//                    IdContinente = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Descripcion = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Continente", x => x.IdContinente);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "DocumentoRespaldo",
//                schema: "Generales",
//                columns: table => new
//                {
//                    IdDocumentoRespaldo = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdDocumentoClasificacion = table.Column<int>(nullable: false),
//                    Sigla = table.Column<string>(nullable: true),
//                    Descripcion = table.Column<string>(nullable: true),
//                    IdFrecuenciaUso = table.Column<int>(nullable: false),
//                    IdDocumentoFormato = table.Column<int>(nullable: false),
//                    NumeroCopias = table.Column<int>(nullable: false),
//                    LugarFisicoArchivado = table.Column<string>(nullable: true),
//                    EsUsadoComoRequisito = table.Column<bool>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false),
//                    Orden = table.Column<int>(nullable: false),
//                    EsObligatorio = table.Column<bool>(nullable: false),
//                    IdProceso = table.Column<int>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_DocumentoRespaldo", x => x.IdDocumentoRespaldo);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "Municipio",
//                schema: "Generales",
//                columns: table => new
//                {
//                    IdMunicipio = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdProvincia = table.Column<int>(nullable: false),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Sigla = table.Column<string>(nullable: true),
//                    Poblacion = table.Column<int>(nullable: false),
//                    IdRegion = table.Column<int>(nullable: false),
//                    GestionCreacion = table.Column<int>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Municipio", x => x.IdMunicipio);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "Pais",
//                schema: "Generales",
//                columns: table => new
//                {
//                    IdPais = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdContinente = table.Column<int>(nullable: false),
//                    CodigoPais = table.Column<string>(nullable: true),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Sigla = table.Column<string>(nullable: true),
//                    CodigoTelefonico = table.Column<string>(nullable: true),
//                    DescripcionIngles = table.Column<string>(nullable: true),
//                    CodigoIso = table.Column<string>(nullable: true),
//                    CodigoAeropuerto = table.Column<string>(nullable: true),
//                    CodigoHorario = table.Column<string>(nullable: true),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_Pais", x => x.IdPais);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "PresupuestoIngreso",
//                schema: "Planificacion",
//                columns: table => new
//                {
//                    IdPresupuestoIngreso = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    Gestion = table.Column<string>(nullable: true),
//                    IdOrganismoFinanciador = table.Column<int>(nullable: false),
//                    IdRubroIngreso = table.Column<int>(nullable: false),
//                    IdUnidadEjecutora = table.Column<int>(nullable: false),
//                    IdDocumentoRespaldo = table.Column<int>(nullable: false),
//                    PptoFormulado = table.Column<decimal>(nullable: false),
//                    PptoAdiciones = table.Column<decimal>(nullable: false),
//                    PptoModificaciones = table.Column<decimal>(nullable: false),
//                    PptoVigente = table.Column<decimal>(nullable: false),
//                    EjecucionDevengado = table.Column<decimal>(nullable: false),
//                    EjecucionRecaudado = table.Column<decimal>(nullable: false),
//                    EjecucionDevuelto = table.Column<decimal>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false),
//                    Descripcion = table.Column<string>(nullable: true)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_PresupuestoIngreso", x => x.IdPresupuestoIngreso);
//                });
//
//            migrationBuilder.CreateTable(
//                name: "VentaContrato",
//                schema: "Ventas",
//                columns: table => new
//                {
//                    IdVentaContrato = table.Column<int>(nullable: false)
//                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
//                    IdVentaSolicitud = table.Column<int>(nullable: false),
//                    IdProcesoNivel2 = table.Column<int>(nullable: false),
//                    Gestion = table.Column<string>(nullable: true),
//                    IdUnidadEjecutora = table.Column<int>(nullable: false),
//                    CorrelativoUnidad = table.Column<int>(nullable: false),
//                    IdDepartamento = table.Column<int>(nullable: false),
//                    FechaVenta = table.Column<DateTime>(nullable: false),
//                    IdBeneficiario = table.Column<int>(nullable: false),
//                    IdBeneficiarioGarante = table.Column<int>(nullable: false),
//                    IdBeneficiarioResponsable = table.Column<int>(nullable: false),
//                    IdVentaTarifario = table.Column<int>(nullable: false),
//                    Descripcion = table.Column<string>(nullable: true),
//                    Observaciones = table.Column<string>(nullable: true),
//                    CiteTramite = table.Column<string>(nullable: true),
//                    IdAsrSiver = table.Column<string>(nullable: false),
//                    MesNumero = table.Column<int>(nullable: false),
//                    FechaInicio = table.Column<DateTime>(nullable: false),
//                    FechaFinal = table.Column<DateTime>(nullable: false),
//                    CantidadTotal = table.Column<decimal>(nullable: false),
//                    TotalBs = table.Column<decimal>(nullable: false),
//                    TotalDolares = table.Column<decimal>(nullable: false),
//                    IdTipoMoneda = table.Column<int>(nullable: false),
//                    TipoCambio = table.Column<decimal>(nullable: false),
//                    TotalPrevisionBs = table.Column<decimal>(nullable: false),
//                    Literal = table.Column<string>(nullable: true),
//                    PlazoMeses = table.Column<int>(nullable: false),
//                    MesInicioCronograma = table.Column<int>(nullable: false),
//                    IdPoa = table.Column<int>(nullable: false),
//                    IdProceso = table.Column<int>(nullable: false),
//                    IdDocumentoRespaldo = table.Column<int>(nullable: false),
//                    NumeroDocumento = table.Column<int>(nullable: false),
//                    ArchivoRespaldo = table.Column<string>(nullable: true),
//                    ArchivoRespaldoCargado = table.Column<bool>(nullable: false),
//                    IdEstadoRegistro = table.Column<int>(nullable: false),
//                    IdUsuario = table.Column<int>(nullable: false),
//                    IdUsuarioAprueba = table.Column<int>(nullable: false),
//                    FechaRegistro = table.Column<DateTime>(nullable: false),
//                    FechaAprueba = table.Column<DateTime>(nullable: false)
//                },
//                constraints: table =>
//                {
//                    table.PrimaryKey("PK_VentaContrato", x => x.IdVentaContrato);
//                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Auxiliar",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "Banco",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "CuentaBancaria",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "Dosificacion",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "PlanCuentas",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "TipoCuentaBanco",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "TipoMoneda",
                schema: "Finanzas");

            migrationBuilder.DropTable(
                name: "Continente",
                schema: "Generales");

            migrationBuilder.DropTable(
                name: "DocumentoRespaldo",
                schema: "Generales");

            migrationBuilder.DropTable(
                name: "Municipio",
                schema: "Generales");

            migrationBuilder.DropTable(
                name: "Pais",
                schema: "Generales");

            migrationBuilder.DropTable(
                name: "PresupuestoIngreso",
                schema: "Planificacion");

            migrationBuilder.DropTable(
                name: "VentaContrato",
                schema: "Ventas");

            migrationBuilder.DropColumn(
                name: "ApellidoCasada",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropColumn(
                name: "IdBarrio",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropColumn(
                name: "IdGenero",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropColumn(
                name: "SegundoNombre",
                schema: "RRHH",
                table: "Beneficiario");

            migrationBuilder.DropColumn(
                name: "Descripcion",
                schema: "Planificacion",
                table: "PresupuestoGasto");
        }
    }
}
