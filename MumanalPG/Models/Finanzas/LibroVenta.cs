using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("LibroVenta", Schema = "Finanzas")]
    public class LibroVenta
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdLibroVenta { get; set; }
        public Int32 IdCobranzaFacturacion { get; set; }
        public string Gestion { get; set; }
        public Int32 Mes { get; set; }
        public DateTime FechaFactura { get; set; }
        public Int32 NumeroFactura { get; set; }
        public string NumeroAutorizacion { get; set; }
        public string EstadoFactura { get; set; }
        public string NitCliente { get; set; }
        public string BeneficiarioDenominacion { get; set; }
        public Decimal ImporteVentaBs { get; set; }
        public Decimal ImporteIceBs { get; set; }
        public Decimal ExportacionesExentasBs { get; set; }
        public Decimal ImporteTasaCeroBs { get; set; }
        public Decimal ImporteSubTotalBs { get; set; }
        public Decimal ImporteDescuentoBs { get; set; }
        public Decimal ImporteBaseDebitoBs { get; set; }
        public Decimal DebitoFiscalBs { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}