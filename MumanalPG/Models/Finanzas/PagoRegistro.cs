using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("PagoRegistro", Schema = "Finanzas")]
    public class PagoRegistro
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPagoRegistro { get; set; }
        public Int32 IdEjecucionGasto { get; set; }
        public string Gestion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string Concepto { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public Int32 IdChequera { get; set; }
        public Int32 NumeroCheque { get; set; }
        public Int32 IdTipoTransaccion { get; set; }
        public Boolean ChequeImpreso { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public Decimal TipoCambio { get; set; }
        public DateTime FechaPago { get; set; }
        public string Literal { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdEstadoBanco { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdUsuarioAprueba { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRegistroAprueba { get; set; }
    }
}
