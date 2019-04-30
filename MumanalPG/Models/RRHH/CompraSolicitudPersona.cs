
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("CompraSolicitudPersona", Schema = "RRHH")]
    public class CompraSolicitudPersona
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraSolicitudPersona { get; set; }
        public Int32 IdCompraSolicitud { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string BeneficiarioDenominacion { get; set; }
        public string DireccionDomicilio { get; set; }
        public string TelefonoReferencia { get; set; }
        public Int32 IdPuesto { get; set; }
        public Int32 IdNivelEducativo { get; set; }
        public Int32 IdProfesion { get; set; }
        public Int32 IdMunicipio { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaSolicitudPersona { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
