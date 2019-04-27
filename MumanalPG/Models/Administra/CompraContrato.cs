using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraContrato", Schema = "Administra")]
    public class CompraContrato
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraContrato { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string ObjetoContrato { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaFirma { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public Int32 forma_inicio_codigo { get; set; }
        public Boolean SeEstableceMultas { get; set; }
        public Int32 TiempoMeses { get; set; }
        public Int32 TiempoDias { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Decimal MontoDolares { get; set; }
        public Decimal MontoBs { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
