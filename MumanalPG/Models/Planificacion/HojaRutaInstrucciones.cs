using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("HojaRutaInstrucciones", Schema = "Planificacion")]
	public class HojaRutaInstrucciones
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdHojaRutaInstruccion { get; set; }
		public Int32 IdHojaRutaDetalle { get; set; }
		public Int32 IdInstruccion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		public string HoraRegistro { get; set; }
	}
}