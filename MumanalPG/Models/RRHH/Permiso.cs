
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("Permiso", Schema = "RRHH")]
    public class Permiso
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPermiso { get; set; }
        public Int32 IdVacacionProgramacion { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string Gestion { get; set; }
        public Int32 MesControl { get; set; }
        public DateTime FechaControl { get; set; }
        public Int32 Item { get; set; }
        public Int32 IdPermisoClasificacion { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public DateTime FechaReincorporacion { get; set; }
        public DateTime HoraDesde { get; set; }
        public DateTime HoraHasta { get; set; }
        public DateTime HoraReincorporacion { get; set; }
        public Decimal DiasDePermiso { get; set; }
        public Int32 HorasPermiso { get; set; }
        public Int32 MinutosPermiso { get; set; }
        public Int32 TotalMinutosPermiso { get; set; }
        public string CiteMemoranda { get; set; }
        public string PathArchivo { get; set; }
        public Boolean ArchivoCargado { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}