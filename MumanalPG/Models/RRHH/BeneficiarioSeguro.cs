
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("BeneficiarioSeguro", Schema = "RRHH")]
    public class BeneficiarioSeguro
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBeneficiarioSeguro { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdBeneficiarioEntidad { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaSalida { get; set; }
        public string MatriculaAsegurado { get; set; }
        public string TituloContrato { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}