using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraContratacionCotiza", Schema = "Administra")]
    public class CompraContratacionCotiza
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraContratacionCotiza { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public DateTime FechaCotiza { get; set; }
        public string NumeroVentaPliego { get; set; }
        public string CiteCarta { get; set; }
        public string NumeroCotizacionProveedor { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string NombreProveedorQueCotiza { get; set; }
        public DateTime FechaEstimadaCompra { get; set; }
        public DateTime FechaLimiteCotizacion { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
