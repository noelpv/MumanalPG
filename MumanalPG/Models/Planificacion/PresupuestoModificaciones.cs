using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models;
using MumanalPG.Utility;

namespace MumanalPG.Models.Planificacion
{
	[Table("PresupuestoModificaciones", Schema = "Planificacion")]
	public class PresupuestoModificaciones
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPresupuestoModificaciones { get; set; }
		public string Gestion { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 NumeroRespaldo { get; set; }
		public DateTime FechaAutorizacion { get; set; }
		public Int32 IdPoa { get; set; }
		public Int32 IdPresupuestoGasto { get; set; }
		public Decimal MontoOrigen { get; set; }
		public Int32 IdPoaDestino { get; set; }
		public Int32 IdPresupuestoGastoDestino { get; set; }
		public Decimal MontoDestino { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}