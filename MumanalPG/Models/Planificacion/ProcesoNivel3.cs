using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("ProcesoNivel3", Schema = "Planificacion")]
	public class ProcesoNivel3
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdProcesoNivel3 { get; set; }
		public Int32 IdProcesoNivel2 { get; set; }
		public string Descripcion { get; set; }
		public Int32 NumeroDiasHabiles { get; set; }
		public Int32 NumeroDiasCalendario { get; set; }
		public Int32 IdDocumentosRespaldo { get; set; }
		public Int32 IdFormulario { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}