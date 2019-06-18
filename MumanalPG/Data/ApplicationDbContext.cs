using MumanalPG.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Models.Generales;
using MumanalPG.Models.Administra;
using MumanalPG.Models.Correspondencia;
using MumanalPG.Models.Planificacion;
using MumanalPG.Models.Ventas;


namespace MumanalPG.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ProductTypes> ProductTypes { get; set; }
        public DbSet<SpecialTags> SpecialTags { get; set; }
        public DbSet<Products> Products { get; set; }

        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<ProductsSelectedForAppointment> ProductsSelectedForAppointment { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        /*Ini Generales*/
        public DbSet<MumanalPG.Models.Generales.fBuscaId> Generales_fBuscaId { get; set; }
		public DbSet<MumanalPG.Models.Generales.fRetornaEntero> Generales_fRetornaEntero { get; set; }
		public DbSet<MumanalPG.Models.Generales.fRetornaCadena> Generales_fRetornaCadena { get; set; }
        public DbSet<MumanalPG.Models.Generales.Continente> Continente { get; set; }
        public DbSet<MumanalPG.Models.Generales.Departamento> Departamento { get; set; }
        public DbSet<MumanalPG.Models.Generales.DocumentoRespaldo> DocumentoRespaldo { get; set; }
        public DbSet<MumanalPG.Models.Generales.Municipio> Municipio { get; set; }
        public DbSet<MumanalPG.Models.Generales.Pais> Pais { get; set; }
        /*Fin Generales*/

        /*Ini RRHH*/
        public DbSet<MumanalPG.Models.RRHH.Beneficiario> RRHH_Beneficiario { get; set; }
		public DbSet<MumanalPG.Models.RRHH.Puesto> RRHH_Puesto { get; set; }
		public DbSet<MumanalPG.Models.RRHH.UnidadEjecutora> RRHH_UnidadEjecutora { get; set; }
		public DbSet<MumanalPG.Models.RRHH.vPersona> RRHH_vPersona { get; set; }
        public DbSet<MumanalPG.Models.RRHH.VacacionProgramacion> VacacionProgramacion { get; set; }
        public DbSet<MumanalPG.Models.RRHHParam.TipoBeneficiario> RRHHParam_TipoBeneficiario { get; set; }
        public DbSet<MumanalPG.Models.RRHH.BeneficiarioCategoria> BeneficiarioCategoria { get; set; }
        /*Fin RRHH*/

        /*Ini Finanzas*/
        public DbSet<MumanalPG.Models.Finanzas.Auxiliar> Auxiliar { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.Banco> Banco { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.CuentaBancaria> CuentaBancaria { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.Dosificacion> Dosificacion { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.PlanCuentas> PlanCuentas { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.TipoTransaccion> TipoTransaccion { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.TipoCuentaBanco> TipoCuentaBanco { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.TipoMoneda> TipoMoneda { get; set; }
        public DbSet<MumanalPG.Models.Finanzas.TipoComprobante> TipoComprobante { get; set; }
        /*Fin Finanzas*/

        /*Ini Prestaciones*/
        public DbSet<MumanalPG.Models.Ventas.DocumentoRespaldo> Ventas_DocumentoRespaldo { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vContratacion> Ventas_vContratacion { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vRequisito> Ventas_vRequisito { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaContratacion> Ventas_VentaContratacion { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaRequisito> Ventas_VentaRequisito { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaTarifario> VentaTarifario { get; set; }
        public DbSet<MumanalPG.Models.Ventas.pVerificaLimite> Ventas_pVerificaLimite { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaSolicitud> VentaSolicitud { get; set; }
        public DbSet<MumanalPG.Models.Ventas.TablaPDF> TablaPDF { get; set; }
        /*Fin Prestaciones*/

        public DbSet<MumanalPG.Models.Seguridad.UsuarioUnidadEjecutora> Seguridad_UsuarioUnidadEjecutora { get; set; }
		public DbSet<MumanalPG.Models.Seguridad.Usuario> Seguridad_Usuario { get; set; }

		public DbSet<MumanalPG.Models.RoleViewModel> RoleViewModel { get; set; }

        /*Ini Administrativo*/
        public DbSet<MumanalPG.Models.Administra.TipoAlmacen> TipoAlmacen { get; set; }
        public DbSet<MumanalPG.Models.Administra.Almacen> Almacen { get; set; }
        public DbSet<MumanalPG.Models.Administra.AlmacenIngreso> AlmacenIngreso { get; set; }
        public DbSet<MumanalPG.Models.Administra.AlmacenInventario> AlmacenInventario { get; set; }
        public DbSet<MumanalPG.Models.Administra.AlmacenSalida> AlmacenSalida { get; set; }
        public DbSet<MumanalPG.Models.Administra.Bienes> Bienes { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraContratacion> CompraContratacion { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraContratacionBien> CompraContratacionBien { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraContratacionCotiza> CompraContratacionCotiza { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraCronograma> CompraCronograma { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraSolicitud> CompraSolicitud { get; set; }
        public DbSet<MumanalPG.Models.Administra.CompraSolicitudBien> CompraSolicitudBien { get; set; }
        public DbSet<MumanalPG.Models.Administra.ActivoAsignacion> ActivoAsignacion { get; set; }
        public DbSet<MumanalPG.Models.Administra.ActivoFijo> ActivoFijo { get; set; }
        public DbSet<MumanalPG.Models.Administra.ActivoTransferencia> ActivoTransferencia { get; set; }
        /*Fin Administrativo*/

        /*Ini Planificacion*/
        public DbSet<MumanalPG.Models.Planificacion.PresupuestoGasto> PresupuestoGasto { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.PresupuestoIngreso> PresupuestoIngreso { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.PresupuestoModificaciones> PresupuestoModificaciones { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.FuenteFinanciamiento> FuenteFinanciamiento { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.OrganismoFinanciador> OrganismoFinanciador { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.EstructuraProgramatica> EstructuraProgramatica { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.PartidaGasto> PartidaGasto { get; set; }
        public DbSet<MumanalPG.Models.Planificacion.RubroIngreso> RubroIngreso { get; set; }

        public DbSet<MumanalPG.Models.Planificacion.HojaRutaInstrucciones> HojaRutaInstrucciones { get; set; }
        //public DbSet<MumanalPG.Models.Planificacion.HojaRutaDocumentos> HojaRutaDocumentos { get; set; }
        /*Fin Planificacion*/

        /*Correspondencia*/
        public DbSet<TipoDocumento> CorrespondenciaTipoDocumento { get; set; }
	    public DbSet<MumanalPG.Models.Correspondencia.Instrucciones> CorrespondenciaInstrucciones { get; set; }
	    public DbSet<Documento> CorrespondenciaDocumento { get; set; }
	    public DbSet<HojaRuta> CorrespondenciaHojaRuta { get; set; }
	    public DbSet<HojaRutaDetalle> CorrespondenciaHRDetalle { get; set; }
	    public DbSet<HRDetalleInstrucciones> CorrespondenciaHRDetInst { get; set; }
	    public DbSet<Anexo> CorrespondenciaAnexo { get; set; }
	    public DbSet<TipoAnexo> CorrespondenciaTipoAnexo { get; set; }
	    /* End Correspondencia*/
	    
    }
}
