using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("DocumentoRespaldo", Schema = "Ventas")]
	public class DocumentoRespaldo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 IdDocumentoClasificacion { get; set; }
		public string Sigla { get; set; }
		public string Descripcion { get; set; }
		public Int32 IdFrecuenciaUso { get; set; }
		public Int32 IdDocumentoFormato { get; set; }
		public Int32 NumeroCopias { get; set; }
		public string LugarFisicoArchivado { get; set; }
		public Boolean EsUsadoComoRequisito { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}