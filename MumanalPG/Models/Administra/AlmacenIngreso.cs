
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("AlmacenIngreso", Schema = "Administra")]
    public class AlmacenIngreso
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAlmacenIngreso { get; set; }
        public Int32 IdCompraContratacionBien { get; set; }
        public Int32 IdAlmacenInventario { get; set; }
        public Int32 IdAlmacen { get; set; }
        public Int32 IdBienes { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioAlmacenero { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string NumeroLote { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public Decimal CantidadIngreso { get; set; }
        public Decimal CostoUnitarioBs { get; set; }
        public Decimal SubTotalCompraBs { get; set; }
        public Decimal SubTotalCompraDolares { get; set; }
        public string Concepto { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
