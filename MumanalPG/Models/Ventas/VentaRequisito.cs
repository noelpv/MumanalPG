using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("VentaRequisito", Schema = "Ventas")]
	public class VentaRequisito
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdVentaRequisito { get; set; }
		public Int32 IdVentaContratacion { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 IdDocumentoFormato { get; set; }
		public Boolean DocumentoEntregado { get; set; }
		public string PathArchivo { get; set; }
		public Boolean ArchivoCargado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}