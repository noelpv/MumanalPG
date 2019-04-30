using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PagoGrupo", Schema = "RRHH")]
    public class PagoGrupo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPagoPlanilla { get; set; }
        public string ges_gestion { get; set; }
        public Int32 IdPlanillaGrupo { get; set; }
        public Int32 MesPago { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdDepartamento { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdUsuarioAprueba { get; set; }
        public DateTime FechaAprueba { get; set; }
    }
}