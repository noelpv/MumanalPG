using System;
using System.Collections.Generic;
using System.Text;
using MumanalPG.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Models.FinanzasParam;
using MumanalPG.Models.AdministraParam;
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

        public DbSet<MumanalPG.Models.FinanzasParam.Partida> Partida { get; set; }

        public DbSet<MumanalPG.Models.AdministraParam.Grupo> Grupo { get; set; }
        public DbSet<MumanalPG.Models.AdministraParam.SubGrupo> SubGrupo { get; set; }
	       

		public DbSet<MumanalPG.Models.RRHH.Beneficiario> RRHH_Beneficiario { get; set; }
		public DbSet<MumanalPG.Models.RRHH.UnidadEjecutora> RRHH_UnidadEjecutora { get; set; }
		public DbSet<MumanalPG.Models.RRHHParam.TipoBeneficiario> RRHHParam_TipoBeneficiario { get; set; }
		public DbSet<MumanalPG.Models.Ventas.DocumentoRespaldo> Ventas_DocumentoRespaldo { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vContratacion> Ventas_vContratacion { get; set; }
		public DbSet<MumanalPG.Models.Ventas.vRequisito> Ventas_vRequisito { get; set; }
        public DbSet<MumanalPG.Models.Ventas.VentaContratacion> Ventas_VentaContratacion { get; set; }
		public DbSet<MumanalPG.Models.Ventas.VentaRequisito> Ventas_VentaRequisito { get; set; }

		public DbSet<MumanalPG.Models.Ventas.pVerificaLimite> Ventas_pVerificaLimite { get; set; }

		public DbSet<MumanalPG.Models.Ventas.TablaPDF> TablaPDF { get; set; }
	}
}
