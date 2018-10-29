using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("FrecuenciaUso", Schema = "Planificacion")]
	public class FrecuenciaUso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdFrecuenciaUso { get; set; }
		public string Descripcion { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
