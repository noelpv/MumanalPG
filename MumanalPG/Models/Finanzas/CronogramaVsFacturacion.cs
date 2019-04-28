
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("CronogramaVsFacturacion", Schema = "Finanzas")]
    public class CronogramaVsFacturacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCronogramaVsFacturacion { get; set; }
        public Int32 IdCobranzaCronograma { get; set; }
        public Int32 IdCobranzaFacturacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
