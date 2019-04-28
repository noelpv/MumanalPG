using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("EjecucionIngreso", Schema = "Finanzas")]
    public class EjecucionIngreso
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdEjecucionIngreso { get; set; }
        public string Gestion { get; set; }
        public Int32 IdPresupuestoIngreso { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public Int32 IdVentaContratacion { get; set; }
        public Int32 IdVentaSolicitud { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public string Concepto { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public string NumeroFactura { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

