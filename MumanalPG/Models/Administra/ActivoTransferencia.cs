using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("ActivoTransferencia", Schema = "Administra")]
    public class ActivoTransferencia
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdActivoTransferencia { get; set; }
        public Int32 IdActivoFijo { get; set; }
        public Int32 IdAlmacen { get; set; }
        public Int32 IdAlmacenDestino { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdUnidadEjecutoraDestino { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioDestino { get; set; }
        public Int32 IdBeneficiarioEncargado { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaTransferencia { get; set; }
        public Int32 IdEstadoActivoFijo { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
    }
}
