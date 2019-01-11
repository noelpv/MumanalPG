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
		public Int32 IdVentaContratacion { get; set; } // correlativo general, nose usa para nada mas
		public Int32 IdVentaSolicitud { get; set; }
		public Int32 IdProcesoNivel2 { get; set; }   // tabla procesosnivel 1=ASR, 2=Bono cesantia, 3=cuota mortuoria
		public string Gestion { get; set; }
		public Int32 IdUnidadEjecutora { get; set; } //resuelto
		[Display(Name = "Nro Solicitud")]
		[Required(ErrorMessage = "Se requiere el Nro Solicitud")]
		public Int32 CorrelativoUnidad { get; set; } // correlativo de la unidad ejecutora
		public Int32 IdDepartamento { get; set; }
		[Display(Name = "Fecha")]
		[Required(ErrorMessage = "Se requiere la Fecha")]
		public DateTime FechaVenta { get; set; }
		public Int32 IdBeneficiario { get; set; }
		[Display(Name = "Garante")]
		[Required(ErrorMessage = "Se requiere el Garante")]
		public Int32 IdBeneficiarioGarante { get; set; }
		public Int32 IdBeneficiarioResponsable { get; set; }
		public Int32 IdVentaTarifario { get; set; }
		public string Concepto { get; set; }
		public string Observaciones { get; set; }
		public string CiteTramite { get; set; }
		[Display(Name = "Número ASR")]
		[Required(ErrorMessage = "Se requiere el Número ASR")]
		public string IdAsrSiver { get; set; }  // correlativo por proceso : asr de 1 a n, cesantia  de 1 a N, 
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
