using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Municipio", Schema = "Generales")]
	public class Municipio
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdMunicipio { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Provincia")]
		public Int32 IdProvincia { get; set; }
		public Provincia ProvinciaDB { get; set;}
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		public string Sigla { get; set; }
		[Range(0, Int32.MaxValue, ErrorMessage = "No es un número válido")]
		[Display(Name="Población")]
		public Int32 Poblacion { get; set; }
		public Int32 IdRegion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(4, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Gestión de Creación")]
		public string GestionCreacion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
