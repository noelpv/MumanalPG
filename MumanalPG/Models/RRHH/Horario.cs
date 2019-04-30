
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("Horario", Schema = "RRHH")]
    public class Horario
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdHorario { get; set; }
        public Int32 IdTurno { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Gestion { get; set; }
        public string Descripcion { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public string HoraTopeIngreso { get; set; }
        public string MinutosTolerancia { get; set; }
        public Boolean TieneHoraExtra { get; set; }
        public Decimal NumeroHoras { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}