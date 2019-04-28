
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("FacturacionVsCobranza", Schema = "Finanzas")]
    public class FacturacionVsCobranza
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdFacturacionVsCobranza { get; set; }
        public Int32 IdCobranzaFacturacion { get; set; }
        public Int32 IdCobranzaRegistro { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}

