
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraSolicitudBien", Schema = "Administra")]
    public class CompraSolicitudBien
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraSolicitudBien { get; set; }
        public Int32 IdCompraSolicitud { get; set; }
        public Int32 IdBienes { get; set; }
        public Int32 IdModelo { get; set; }
        public Int32 IdPais { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public Int32 IdUnidadMedidaEmpaque { get; set; }
        public Decimal CantidadSolicitada { get; set; }
        public Decimal CantidadPorEmpaque { get; set; }
        public Decimal CantidadAprobada { get; set; }
        public Decimal PrecioUnitario { get; set; }
        public Decimal PrecioTotalReferencial { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}