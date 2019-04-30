
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("UnidadVsResponsable", Schema = "RRHH")]
    public class UnidadVsResponsable
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdUnidadVsResponsable { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string EsJefe { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}