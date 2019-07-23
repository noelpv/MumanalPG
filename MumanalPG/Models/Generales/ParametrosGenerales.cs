using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("ParametrosGenerales", Schema = "Generales")]
	public class ParametrosGenerales
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdParametrosGenerales { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Gestion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Nombre del Servidor")]
		public String NombreServidor { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Nombre de la Base de Datos")]
		public String NombreBD { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Directorio de Sistema (path)")]
		public String PathSistema { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Directorio de Documentos (path)")]
		public String PathDocumentos { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Codigo de Municipio")]
		public Int32 MunicipioCodigo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}