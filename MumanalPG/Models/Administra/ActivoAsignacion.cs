using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("ActivoAsignacion", Schema = "Administra")]
    public class ActivoAsignacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdActivoFijo { get; set; }
        public Int32 IdAlmacenInventario { get; set; }
        public Int32 IdBienes { get; set; }
        public string CodigoActivoFijo { get; set; }
        public string CodigoAdministrativo { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public Decimal Ufv { get; set; }
        public Decimal CostoInicial { get; set; }
        public Decimal DepreciacionAcumuladaInicial { get; set; }
        public Decimal FactorActualizacion { get; set; }
        public Decimal ValorActual { get; set; }
        public Decimal DepreciacionAcumulada { get; set; }
        public Decimal DepreciacionGestion { get; set; }
        public Decimal ValorNeto { get; set; }
        public Int32 TiempoVidaEnAnios { get; set; }
        public Int32 TiempoVidaEnDias { get; set; }
        public string CodigoRube { get; set; }
        public Int32 IdOrganismoFinanciador { get; set; }
        public Int32 IdEstadoActivoFijo { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
