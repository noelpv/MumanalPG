
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("MovilidadPersona", Schema = "RRHH")]
    public class MovilidadPersona
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdMobilidadPersona { get; set; }
        public string Gestion { get; set; }
        public Int32 IdMemoranda { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public DateTime FechaElaboracion { get; set; }
        public Int32 IdResolucionTipo { get; set; }
        public string NumeroResolucion { get; set; }
        public DateTime FechaResolucion { get; set; }
        public DateTime FechaInicioContrato { get; set; }
        public string PeriodoPorUnidad { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdCargo { get; set; }
        public Int32 IdPuesto { get; set; }
        public Int32 Item { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public string GestionAnterior { get; set; }
        public string PeriodoPorUnidadAnterior { get; set; }
        public Int32 IdUnidadEjecutoraAnterior { get; set; }
        public string IdCargoAnterior { get; set; }
        public Int32 IdPuestoAnterior { get; set; }
        public Int32 ItemAnterior { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
