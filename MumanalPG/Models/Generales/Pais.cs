using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Pais", Schema = "Generales")]
	public class Pais
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPais { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Continente")]
		public Int32 IdContinente { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(3, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código de País")]
		public string CodigoPais { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		public string Sigla { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código Telefónico")]
		public string CodigoTelefonico { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción en Ingles")]
		public string DescripcionIngles { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código ISO")]
		public string CodigoIso { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código Aeropuerto")]
		public string CodigoAeropuerto { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código Horario")]
		public string CodigoHorario { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
