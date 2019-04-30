
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("BeneficiarioDependiente", Schema = "RRHH")]
    public class BeneficiarioDependiente
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBeneficiarioDependiente { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string CodigoAsegurado { get; set; }
        public DateTime FechaAsegurado { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string DenominacionBeneficiario { get; set; }
        public Int32 IdPersonalParentesco { get; set; }
        public Int32 IdProfesion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}