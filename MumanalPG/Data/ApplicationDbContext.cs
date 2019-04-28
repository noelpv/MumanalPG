
using MumanalPG.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Models.Generales;
using MumanalPG.Models.Administra;


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

        public DbSet<MumanalPG.Models.FinanzasParam.Partida> Partida { get; set; }

        public DbSet<MumanalPG.Models.AdministraParam.Grupo> Grupo { get; set; }
        public DbSet<MumanalPG.Models.AdministraParam.SubGrupo> SubGrupo { get; set; }


		public DbSet<MumanalPG.Models.Generales.fBuscaId> Generales_fBuscaId { get; set; }
		public DbSet<MumanalPG.Models.Generales.fRetornaEntero> Generales_fRetornaEntero { get; set; }
		public DbSet<MumanalPG.Models.Generales.fRetornaCadena> Generales_fRetornaCadena { get; set; }

		public DbSet<MumanalPG.Models.RRHH.Beneficiario> RRHH_Beneficiario { get; set; }
		public DbSet<MumanalPG.Models.RRHH.UnidadEjecutora> RRHH_UnidadEjecutora { get; set; }
		public DbSet<MumanalPG.Models.RRHH.vPersona> RRHH_vPersona { get; set; }
		public DbSet<MumanalPG.Models.RRHHParam.TipoBeneficiario> RRHHParam_TipoBeneficiario { get; set; }
		public DbSet<MumanalPG.Models.Ventas.DocumentoRespaldo> Ventas_DocumentoRespaldo { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vContratacion> Ventas_vContratacion { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vRequisito> Ventas_vRequisito { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaContratacion> Ventas_VentaContratacion { get; set; }
		public DbSet<MumanalPG.Models.Ventas.VentaRequisito> Ventas_VentaRequisito { get; set; }

		public DbSet<MumanalPG.Models.Ventas.pVerificaLimite> Ventas_pVerificaLimite { get; set; }

		public DbSet<MumanalPG.Models.Ventas.TablaPDF> TablaPDF { get; set; }

		public DbSet<MumanalPG.Models.Seguridad.UsuarioUnidadEjecutora> Seguridad_UsuarioUnidadEjecutora { get; set; }
		public DbSet<MumanalPG.Models.Seguridad.Usuario> Seguridad_Usuario { get; set; }

		public DbSet<MumanalPG.Models.RoleViewModel> RoleViewModel { get; set; }

		public DbSet<MumanalPG.Models.Generales.Departamento> Departamento { get; set; }

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
	}
}
