using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Calle", Schema = "Generales")]
	public class Calle
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdCalle { get; set; }
		public Int32 IdBarrio { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		public Int32 IdCalleTipo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}