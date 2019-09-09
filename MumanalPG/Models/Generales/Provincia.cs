using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Provincia", Schema = "Generales")]
	public class Provincia
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdProvincia { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Departamento")]
		public Int32 IdDepartamento { get; set; }
		public Departamento DepartamentoDB { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		public string Sigla { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
