using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Pais", Schema = "Generales")]
	public class Pais
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPais { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdContinente { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string CodigoPais { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Sigla { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string CodigoTelefonico { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string DescripcionIngles { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string CodigoIso { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string CodigoAeropuerto { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string CodigoHorario { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
