
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PlanillaSubGrupo", Schema = "RRHH")]
    public class PlanillaSubGrupo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPlanillaSubGrupo { get; set; }
        public Int32 IdPlanillaGrupo { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public Boolean EsDePlanilla { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}