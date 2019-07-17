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
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Gestion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdOrganismoFinanciador { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdRubroIngreso { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdUnidadEjecutora { get; set; }
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
        public Decimal EjecucionDevengado { get; set; }
		public Decimal EjecucionRecaudado { get; set; }
		public Decimal EjecucionDevuelto { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string  Descripcion { get; set; }
    }
}
