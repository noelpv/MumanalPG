using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("Usuario", Schema = "Ventas")]
	public class Usuario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdUsuario { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public string BeneficiarioDescripcion { get; set; }
		public string Contrasena { get; set; }
		public string Observaciones { get; set; }
		public Int32 IdNivelAcceso { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuarioTabla { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}