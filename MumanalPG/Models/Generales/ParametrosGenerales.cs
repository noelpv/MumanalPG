using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("ParametrosGenerales", Schema = "Generales")]
	public class ParametrosGenerales
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdParametrosGenerales { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(4, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Gestión")]
		public String Gestion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Nombre del Servidor")]
		public String NombreServidor { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Nombre de la Base de Datos")]
		public String NombreBD { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Directorio de Sistema (path)")]
		public String PathSistema { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Directorio de Documentos (path)")]
		public String PathDocumentos { get; set; }
		[Range(0, Int32.MaxValue, ErrorMessage = "No es un número válido")]
		[Display(Name="Código de Municipio")]
		public Int32 MunicipioCodigo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}