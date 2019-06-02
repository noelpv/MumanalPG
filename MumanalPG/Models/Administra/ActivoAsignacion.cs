using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("ActivoAsignacion", Schema = "Administra")]
    public class ActivoAsignacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdActivoAsignacion { get; set; }
        public Int32 IdActivoFijo { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdBeneficiarioDestino { get; set; }
        public Int32 IdUnidadEjecutoraDestino { get; set; }

        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
