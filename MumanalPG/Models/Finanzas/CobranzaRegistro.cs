using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("CobranzaRegistro", Schema = "Finanzas")]
    public class CobranzaRegistro
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCobranzaRegistro { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public string Gestion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public Decimal ImporteCobradoBs { get; set; }
        public Decimal ImporteCobradoDolar { get; set; }
        public Decimal TipoCambio { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public DateTime FechaCobranza { get; set; }
        public string Concepto { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public string ComprobanteDeposito { get; set; }
        public Int32 IdTipoTransaccion { get; set; }
        public Int32 IdDepartamento { get; set; }
        public string literal { get; set; }
        public Int32 IdEstadoRegistroBanco { get; set; }
        public Int32 IdUsuarioAprueba { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaRegistroAprueba { get; set; }
    }
}
