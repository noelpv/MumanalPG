
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("AlmacenInventario", Schema = "Administra")]
    public class AlmacenInventario
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAlmacenInventario { get; set; }
        public Int32 IdAlmacen { get; set; }
        public Int32 IdBienes { get; set; }
        public Decimal StockIngreso { get; set; }
        public Decimal StockSalida { get; set; }
        public Decimal StockActual { get; set; }
        public Decimal TotalCompraBs { get; set; }
        public Decimal TotalVentaBs { get; set; }
        public Decimal UtilidadBs { get; set; }
        public Decimal TotalCompraDolares { get; set; }
        public Decimal TotalVentaDolares { get; set; }
        public Decimal UtilidadDolares { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}