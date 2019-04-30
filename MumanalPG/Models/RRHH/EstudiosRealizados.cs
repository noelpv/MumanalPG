
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("EstudiosRealizados", Schema = "RRHH")]
    public class EstudiosRealizados
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdEstudiosRealizados { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string CarreraOCurso { get; set; }
        public string CentroEducativo { get; set; }
        public string TituloObtenido { get; set; }
        public Int32 IdNivelEducativo { get; set; }
        public Int32 TiempoDuracion { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public Int32 IdPais { get; set; }
        public string Ciudad { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public Boolean PresentoDocumento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
