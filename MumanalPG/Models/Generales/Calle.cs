using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Calle", Schema = "Generales")]
	public class Calle
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdCalle { get; set; }
		[Display(Name="Barrio")]
		public Int32 IdBarrio { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		[Display(Name="Tipo de Calle")]
		public Int32 IdCalleTipo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}