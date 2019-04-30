
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("VacacionParametro", Schema = "RRHH")]
    public class VacacionParametro
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdVacacionParametro { get; set; }
        public Int32 ParametroInicial { get; set; }
        public Int32 ParametroFinal { get; set; }
        public Int32 DiasVacacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}