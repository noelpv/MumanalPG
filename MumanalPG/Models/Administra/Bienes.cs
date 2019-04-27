
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("Bienes", Schema = "Administra")]
    public class Bienes
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBienes { get; set; }
        public Int32 IdPartidaGasto { get; set; }
        public string CodigoBien { get; set; }
        public string Descripcion { get; set; }
        public string Observacion { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public Int32 IdUnidadMedidaEmpaque { get; set; }
        public Int32 IdModelo { get; set; }
        public Int32 IdPais { get; set; }
        public string CodigoBienAnterior { get; set; }
        public string DescripcionAnterior { get; set; }
        public Int32 IdRotacionBien { get; set; }
        public string NombreArchivo { get; set; }
        public string Foto { get; set; }
        public Int32 Kit { get; set; }
        public Decimal StockMinimo { get; set; }
        public Decimal StockInicial { get; set; }
        public Decimal StockIngreso { get; set; }
        public Decimal StockSalida { get; set; }
        public Decimal StockActual { get; set; }
        public Decimal PrecioReferenciaCompra { get; set; }
        public Decimal PrecioVentaBase { get; set; }
        public Decimal PrecioVentaFinal { get; set; }
        public Decimal TotalAcumuladoCompraBs { get; set; }
        public Decimal TotalAcumuladoVentaBs { get; set; }
        public Decimal TotalUtilidadBs { get; set; }
        public Int32 IdEstadoVigente { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}