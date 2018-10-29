using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PartidaGasto", Schema = "Planificacion")]
	public class PartidaGasto
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPartidaGasto { get; set; }
		public Int32 IdBienesSubgrupo { get; set; }
		public string Descripcion { get; set; }
		public string Gestion { get; set; }
		public string VidaUtil { get; set; }
		public string CoeficienteDepreciacion { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
