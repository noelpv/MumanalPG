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
		public String Gestion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		public String NombreServidor { get; set; }
		public String NombreBD { get; set; }
		public String PathSistema { get; set; }
		public String PathDocumentos { get; set; }
		public Int32 MunicipioCodigo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}