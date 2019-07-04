using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("Proceso", Schema = "Planificacion")]
	public class Proceso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdProceso { get; set; }
		public string Descripcion { get; set; }
		public Int32 IdProcesoPadre { get; set; }
		public Int32 Nivel { get; set; }
		public Boolean EsUltimoNivel { get; set; }
		public Int32 NumeroDiasHabiles { get; set; }
		public Int32 NumeroDiasCalendario { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 IdSistemaFormulario { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}