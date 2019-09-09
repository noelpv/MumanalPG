using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Barrio", Schema = "Generales")]
	public class Barrio
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdBarrio { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Zona")]
		public Int32 IdZona { get; set; }
		public Zona ZonaDB { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}