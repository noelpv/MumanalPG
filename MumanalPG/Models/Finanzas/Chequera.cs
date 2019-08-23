using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Chequera", Schema = "Finanzas")]
    public class Chequera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdChequera { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public DateTime FechaChequera { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public Int32 CorrelativoInicial { get; set; }
        public Int32 CorrelativoFinal { get; set; }
        public Int32 CorrelativoCheque { get; set; }
        public DateTime FechaInicial { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Observacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}