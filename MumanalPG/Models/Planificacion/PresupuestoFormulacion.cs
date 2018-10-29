using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PresupuestoFormulacion", Schema = "Planificacion")]
	public class PresupuestoFormulacion
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPresupuestoFormulacion { get; set; }
		public string Gestion { get; set; }
		public Int32 IdUnidadNivel3 { get; set; }
		public Int32 IdEstructuraProgramatica { get; set; }
		public Int32 IdOrganismoFinanciador { get; set; }
		public Int32 IdPartidaGasto { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdBeneficiarioResponsable { get; set; }
		public Decimal PptoFormulado { get; set; }
		public Decimal PptoAdiciones { get; set; }
		public Decimal PptoModificaciones { get; set; }
		public Decimal PptoVigente { get; set; }
		public Decimal EjecucionCompromiso { get; set; }
		public Decimal EjecucionDevengado { get; set; }
		public Decimal EjecucionPagado { get; set; }
		public Decimal EjecucionDevuelto { get; set; }
		public Decimal EjecucionRevertido { get; set; }
		public Decimal EjecucionAnulado { get; set; }
		public string EstadoCodigo { get; set; }
		public string EstadoCodigoPpto { get; set; }
		public string UsuarioCodigo { get; set; }
		public string UsuarioCodigoAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaAprueba { get; set; }
	}
}
