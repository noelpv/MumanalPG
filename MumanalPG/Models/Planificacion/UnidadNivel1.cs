using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("UnidadNivel1", Schema = "Planificacion")]
	public class UnidadNivel1
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdUnidadNivel1 { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}