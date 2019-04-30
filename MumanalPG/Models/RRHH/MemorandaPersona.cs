
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("MemorandaPersona", Schema = "RRHH")]
    public class MemorandaPersona
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdMemorandaPersona { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string Gestion { get; set; }
        public Int32 IdMemoranda { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaMemo { get; set; }
        public DateTime FechaAprobacion { get; set; }
        public Decimal Importe { get; set; }
        public Int32 Minutos { get; set; }
        public Int32 Dias { get; set; }
        public string GestionDescuento { get; set; }
        public string MesDescuento { get; set; }
        public string PathArchivo { get; set; }
        public Boolean ArchivoCargado { get; set; }
        public Boolean SeDescuentaPorPlanilla { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}