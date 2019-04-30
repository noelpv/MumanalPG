using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PagoCronograma", Schema = "RRHH")]
    public class PagoCronograma
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPagoCronograma { get; set; }
        public Int32 IdPagoPlanilla { get; set; }
        public Int32 NumeroPago { get; set; }
        public Int32 IdPlanillaSubGrupo { get; set; }
        public string Concepto { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Decimal ImporteDolares { get; set; }
        public Decimal ImporteBolivianos { get; set; }
        public DateTime FechaEstimadaPago { get; set; }
        public Decimal TotalAfp { get; set; }
        public Decimal TotalSeguroSocial { get; set; }
        public Decimal TotalUfv { get; set; }
        public Decimal TotalIndemnizacion { get; set; }
        public Decimal TotalAguinaldo { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdUsuarioAprueba { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAprueba { get; set; }
    }
}
