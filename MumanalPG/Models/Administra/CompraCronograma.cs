using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraCronograma", Schema = "Administra")]
    public class CompraCronograma
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraCronograma { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Boolean EmiteFactura { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaCronograma { get; set; }
        public Decimal MontoDolares { get; set; }
        public Decimal MontoBs { get; set; }
        public Decimal DescuentoBs { get; set; }
        public Decimal CompraTotalBs { get; set; }
        public Decimal CompraTotalDolares { get; set; }
        public Decimal TipoCambio { get; set; }
        public string Literal { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}