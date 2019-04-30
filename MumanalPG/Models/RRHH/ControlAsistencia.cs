
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("ControlAsistencia", Schema = "RRHH")]
    public class ControlAsistencia
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdControlAsistencia { get; set; }
        public Int32 IdCompraContratacionPersona { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdBiometrico { get; set; }
        public DateTime FechaControl { get; set; }
        public string Gestion { get; set; }
        public Int32 MesControl { get; set; }
        public string MesNombre { get; set; }
        public Int32 DiaDeFechaControl { get; set; }
        public string NombreDiaControl { get; set; }
        public Int32 IdHorario { get; set; }
        public string HoraIngreso { get; set; }
        public string HoraSalida { get; set; }
        public Int32 TotalMinutos { get; set; }
        public Int32 AtrasoMinutos { get; set; }
        public Int32 MinutosTolerancia { get; set; }
        public string HorasExtras { get; set; }
        public string MinutosExtras { get; set; }
        public Int32 Item { get; set; }
        public Boolean IngresoOSalida { get; set; }
        public Boolean EsAtraso { get; set; }
        public Boolean EsFalta { get; set; }
        public string PathArchivo { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
