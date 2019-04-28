
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("LibroCompra", Schema = "Finanzas")]
    public class LibroCompra
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdLibroCompra { get; set; }
        public Int32 IdPagoRegistro { get; set; }
        public string Gestion { get; set; }
        public Int32 Mes { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NitProveedor { get; set; }
        public string BeneficiarioDenominacion { get; set; }
        public Int32 NumeroFactura { get; set; }
        public string NumeroDUI { get; set; }
        public string NumeroAutorizacion { get; set; }
        public Decimal ImporteCompraBs { get; set; }
        public Decimal ImporteSinIvaBs { get; set; }
        public Decimal ImporteSubTotalBs { get; set; }
        public Decimal ImporteDescuentoBs { get; set; }
        public Decimal ImporteBaseBs { get; set; }
        public Decimal CreditoFiscalBs { get; set; }
        public string CodigoControl { get; set; }
        public Int32 TipoCompra { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
