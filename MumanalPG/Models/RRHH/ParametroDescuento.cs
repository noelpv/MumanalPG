
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("ParametroDescuento", Schema = "RRHH")]
    public class ParametroDescuento
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdParametroDescuento { get; set; }
        public Int32 ParametroInicial { get; set; }
        public Int32 ParametroFinal { get; set; }
        public Decimal Porcentaje { get; set; }
        public Decimal Valor { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}