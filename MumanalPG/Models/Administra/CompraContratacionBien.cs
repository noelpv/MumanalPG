using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraContratacionBien", Schema = "Administra")]
    public class CompraContratacionBien
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraContratacionBien { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdBienes { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public Int32 IdUnidadMedidaEmpaque { get; set; }
        public Decimal CantidadCompra { get; set; }
        public Decimal CantidadRecibida { get; set; }
        public Decimal PrecioUnitarioCompraBs { get; set; }
        public Decimal DescuentoCompraBs { get; set; }
        public Decimal PrecioTotalCompraBs { get; set; }
        public Decimal PrecioTotalCompraDolares { get; set; }
        public Decimal Precio87delTotalBs { get; set; }
        public Decimal IdTipoCambio { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
