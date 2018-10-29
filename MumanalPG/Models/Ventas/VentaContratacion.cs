using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("VentaContratacion", Schema = "Ventas")]
	public class VentaContratacion
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdVentaContratacion { get; set; }
		public Int32 IdVentaSolicitud { get; set; }
		public Int32 IdProcesoNivel2 { get; set; }
		public string Gestion { get; set; }
		public Int32 IdUnidadEjecutora { get; set; }
		public Int32 CorrelativoUnidad { get; set; }
		public Int32 IdDepartamento { get; set; }
		public DateTime FechaVenta { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdBeneficiarioGarante { get; set; }
		public Int32 IdBeneficiarioResponsable { get; set; }
		public Int32 IdVentaTarifario { get; set; }
		public string Concepto { get; set; }
		public string Observaciones { get; set; }
		public string CiteTramite { get; set; }
		public string IdAsrSiver { get; set; }
		public Int32 MesNumero { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFinal { get; set; }
		public Decimal CantidadTotal { get; set; }
		public Decimal TotalBs { get; set; }
		public Decimal TotalDolares { get; set; }
		public Int32 IdTipoMoneda { get; set; }
		public Decimal TipoCambio { get; set; }
		public Decimal TotalPrevisionBs { get; set; }
		public string Literal { get; set; }
		public Int32 PlazoMeses { get; set; }
		public Int32 MesInicioCronograma { get; set; }
		public Int32 IdPoa { get; set; }
		public Int32 IdProceso { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 NumeroDocumento { get; set; }
		public string ArchivoRespaldo { get; set; }
		public Boolean ArchivoRespaldoCargado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public Int32 IdUsuarioAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaAprueba { get; set; }
	}
}
