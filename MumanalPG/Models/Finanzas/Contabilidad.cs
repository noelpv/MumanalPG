using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Contabilidad", Schema = "Finanzas")]
    public class Contabilidad
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdContabilidad { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public string Gestion { get; set; }
        public Int32 CorrelativoAsiento { get; set; }
        public Boolean EsIngresoOEgreso { get; set; }
        public Int32 IdEjecucionPpto { get; set; }
        public Int32 IdPagoCobranza { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string Glosa { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
