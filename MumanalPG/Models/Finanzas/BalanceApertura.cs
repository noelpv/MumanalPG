using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("BalanceApertura", Schema = "Finanzas")]
    public class BalanceApertura
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBalanceApertura { get; set; }
        public string Gestion { get; set; }
        public Int32 IdPlanCuentas { get; set; }
        public Decimal SaldoDebeBs { get; set; }
        public Decimal SaldoDebeDolares { get; set; }
        public Decimal SaldoHaberBs { get; set; }
        public Decimal SaldoHaberDolares { get; set; }
        public string CodigoAnterior { get; set; }
        public string CuentaBancaria { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
