
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PlanillaGrupo", Schema = "RRHH")]
    public class PlanillaGrupo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPlanillaGrupo { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public Int32 IdDepartamento { get; set; }
        public string RegistroPatronal { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}