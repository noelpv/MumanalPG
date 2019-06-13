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
		public Int32 IdContinente { get; set; }
		public string CodigoPais { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public string CodigoTelefonico { get; set; }
		public string DescripcionIngles { get; set; }
		public string CodigoIso { get; set; }
		public string CodigoAeropuerto { get; set; }
		public string CodigoHorario { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
