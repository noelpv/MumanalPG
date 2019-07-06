using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("EjecucionGasto", Schema = "Finanzas")]
    public class EjecucionGasto
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdEjecucionGasto { get; set; }
        public string Gestion { get; set; }
        public Int32 IdPresupuestoGasto { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdCompraSolicitud { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public DateTime FechaGasto { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public string Concepto { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public string NumeroChequeTransferencia { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
