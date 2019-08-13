using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("CobranzaFacturacion", Schema = "Finanzas")]
    public class CobranzaFacturacion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCobranzaFacturacion { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 IdDosificacion { get; set; }
        public string NumeroAutorizacion { get; set; }
        public Int32 NumeroFactura { get; set; }
        public Int32 CorrelativoCobranza { get; set; }
        public string Gestion { get; set; }
        public string BeneficiarioIniciales { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public Int32 IdBeneficiarioFacturado { get; set; }
        public Int32 IdDepartamento { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public Decimal InteresBs { get; set; }
        public Decimal InteresDolares { get; set; }
        public Decimal DescuentoBs { get; set; }
        public Decimal DescuentoDolares { get; set; }
        public Decimal TotalAFacturarBs { get; set; }
        public Decimal TotalAFacturarDolares { get; set; }
        public Decimal TipoCambio { get; set; }
        public DateTime FechaFacturacion { get; set; }
        public string Concepto { get; set; }
        public string CodigoControl { get; set; }
        public string Literal { get; set; }
        public Boolean FacturaImpresa { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public string PathArchivoFoto { get; set; }
        public string PathArchivoQr { get; set; }
        public Boolean ArchivoCargado { get; set; }
        public Boolean EsLiquidacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
