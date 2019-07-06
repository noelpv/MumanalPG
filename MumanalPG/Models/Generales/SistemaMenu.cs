using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("SistemaMenu", Schema = "Generales")]
	public class SistemaMenu
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdSistemaMenu { get; set; }
		public String MenuName { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		public Boolean EsTerminal { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}