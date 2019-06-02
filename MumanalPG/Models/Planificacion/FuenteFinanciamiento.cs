using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("FuenteFinanciamiento", Schema = "Planificacion")]
	public class FuenteFinanciamiento
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdFuenteFinanciamiento { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public string IdEstadoRegistro { get; set; }
		public string IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}