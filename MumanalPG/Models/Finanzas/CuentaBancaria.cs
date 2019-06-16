
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("CuentaBancaria", Schema = "Finanzas")]
    public class CuentaBancaria
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCuentaBancaria { get; set; }
        public Int32 IdBanco { get; set; }
        public string CuentaCodigo { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdTipoCuentaBanco { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public string CodigoTgn { get; set; }
        public DateTime FechaApertura { get; set; }
        public Int32 IdOrganismoFinanciador { get; set; }
        public DateTime FechaSaldoInicial { get; set; }
        public Decimal SaldoInicialBs { get; set; }
        public Decimal SaldoInicialDolares { get; set; }
        public Decimal IngresosBs { get; set; }
        public Decimal IngresosDolares { get; set; }
        public Decimal EgresosBs { get; set; }
        public Decimal EgresosDolares { get; set; }
        public Decimal SaldoActualBs { get; set; }
        public Decimal SaldoActualDolares { get; set; }
        public string CodigoSigep { get; set; }
        public Boolean EsCuentaUnica { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
