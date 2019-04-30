
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("ParametroAntiguedad", Schema = "RRHH")]
    public class ParametroAntiguedad
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdParametroAntiguedad { get; set; }
        public Int32 ParametroInicial { get; set; }
        public Int32 ParametroFinal { get; set; }
        public Decimal Porcentaje { get; set; }
        public Int32 Valor { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}