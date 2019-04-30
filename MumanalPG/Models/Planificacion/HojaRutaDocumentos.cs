using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("HojaRutaDocumentos", Schema = "Planificacion")]
	public class HojaRutaDocumentos
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdHojaRutaDocumentos { get; set; }
		public Int32 IdHojaRuta { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public string CiteRespaldo { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string HoraRegistro { get; set; }
	}
}