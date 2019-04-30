
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("VacacionProgramacion", Schema = "RRHH")]
    public class VacacionProgramacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdVacacionProgramacion { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string Gestion { get; set; }
        public Int32 MesControl { get; set; }
        public Int32 Item { get; set; }
        public Int32 IdVacacionParametro { get; set; }
        public Decimal DiasProgramados { get; set; }
        public Int32 HorasProgramadas { get; set; }
        public Int32 MinutosProgramados { get; set; }
        public Decimal DiasUtilizados { get; set; }
        public Int32 HorasUtilizadas { get; set; }
        public Int32 MinutosUtilizados { get; set; }
        public Decimal DiasPendientes { get; set; }
        public Int32 HorasPendientes { get; set; }
        public Int32 MinutosPendientes { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public DateTime FechaReincoporacion { get; set; }
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public DateTime HoraReincorporacion { get; set; }
        public string observaciones { get; set; }
        public string CiteMemoranda { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}