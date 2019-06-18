
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Dosificacion", Schema = "Finanzas")]
    public class Dosificacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdDosificacion { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        [Required]
        public string NumeroAutorizacion { get; set; }
        public DateTime DosificacionFecha { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public Int32 CorrelativoInicial { get; set; }
        public Int32 CorrelativoFinal { get; set; }
        public Int32 CorrelativoFactura { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaLimite { get; set; }
        public string DosificacionLlave { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
