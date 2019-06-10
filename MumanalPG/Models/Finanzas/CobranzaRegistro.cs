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
        public Decimal importe_cobrado_bs { get; set; }
        public Decimal importe_cobrado_dol { get; set; }
        public Decimal tipo_cambio { get; set; }
        public Int32 tipo_moneda { get; set; }
        public DateTime fecha_cobranza { get; set; }
        public string cobranza_concepto { get; set; }
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
