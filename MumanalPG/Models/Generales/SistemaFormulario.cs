using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("SistemaFormulario", Schema = "Generales")]
	public class SistemaFormulario
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdSistemaFormulario { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Nombre de Objeto")]
		public String NombreObjeto { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Menú de Sistema")]
		public Int32 IdSistemaMenu { get; set; }
		public SistemaMenu SistemaMenu { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}