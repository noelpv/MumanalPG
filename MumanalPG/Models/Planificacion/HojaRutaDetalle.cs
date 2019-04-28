using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("HojaRutaDetalle", Schema = "Planificacion")]
	public class HojaRutaDetalle
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdHojaRutaDetalle { get; set; }
		public Int32 IdHojaRuta { get; set; }
		public Int32 IdUnidadEjecutora { get; set; }
		public Int32 IdUnidadEjecutoraDestino { get; set; }
		public Int32 IdUnidadEjecutoraCopia { get; set; }
		public Int32 IdUnidadEjecutoraCoordinar { get; set; }
		public Int32 Idbeneficiario { get; set; }
		public Int32 IdbeneficiarioDestino { get; set; }
		public Int32 IdbeneficiarioCopia { get; set; }
		public Int32 IdbeneficiarioCoordinar { get; set; }
		public Int32 PlazoDias { get; set; }
		public string Proveido { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string HoraRegistro { get; set; }
	}
}