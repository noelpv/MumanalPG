using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("ParametrosGenerales", Schema = "Planificacion")]
	public class ParametrosGenerales
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdParametrosGenerales { get; set; }
		public string Gestion { get; set; }
		public string Descripcion { get; set; }
		public string NombreServidor { get; set; }
		public string NombreBD { get; set; }
		public string CarpetaSistema { get; set; }
		public string CarpetaDatos { get; set; }
		public Int32 MunicipioCodigo { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}