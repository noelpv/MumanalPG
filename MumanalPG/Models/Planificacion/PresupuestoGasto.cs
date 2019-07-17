using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PresupuestoGasto", Schema = "Planificacion")]
	public class PresupuestoGasto
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPresupuestoGasto { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Gestion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdUnidadEjecutora { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdEstructuraProgramatica { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdOrganismoFinanciador { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdPartidaGasto { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdBeneficiario { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdBeneficiarioResponsable { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdDocumentoRespaldo { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Decimal PptoFormulado { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Decimal PptoAdiciones { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Decimal PptoModificaciones { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Decimal PptoVigente { get; set; }
		public Decimal EjecucionCompromiso { get; set; }
		public Decimal EjecucionDevengado { get; set; }
		public Decimal EjecucionPagado { get; set; }
		public Decimal EjecucionDevuelto { get; set; }
		public Decimal EjecucionRevertido { get; set; }
		public Decimal EjecucionAnulado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdEstadoPpto { get; set; }
		public Int32 IdUsuario { get; set; }
		public Int32 IdUsuarioAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaAprueba { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string  Descripcion { get; set; }
        
    }
}
