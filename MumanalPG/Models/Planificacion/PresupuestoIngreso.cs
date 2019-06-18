using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PresupuestoIngreso", Schema = "Planificacion")]
	public class PresupuestoIngreso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPresupuestoIngreso { get; set; }
		public string Gestion { get; set; }
        public Int32 IdOrganismoFinanciador { get; set; }
        public Int32 IdRubroIngreso { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Decimal PptoFormulado { get; set; }
		public Decimal PptoAdiciones { get; set; }
		public Decimal PptoModificaciones { get; set; }
		public Decimal PptoVigente { get; set; }
		public Decimal EjecucionDevengado { get; set; }
		public Decimal EjecucionRecaudado { get; set; }
		public Decimal EjecucionDevuelto { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
        public string  Descripcion { get; set; }
    }
}
