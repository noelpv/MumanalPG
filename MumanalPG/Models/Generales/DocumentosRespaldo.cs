using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("DocumentosRespaldo", Schema = "Planificacion")]
	public class DocumentosRespaldo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentosRespaldo { get; set; }
		public Int32 IdDocumentosClasificacion { get; set; }
		public string Sigla { get; set; }
		public string Descripcion { get; set; }
		public Int32 IdFrecuenciaUso { get; set; }
		public Int32 IdDocumentosFormato { get; set; }
		public Int32 NumeroCopias { get; set; }
		public Int32 IdUnidadNivel3 { get; set; }
		public string LugarFisicoArchivado { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}