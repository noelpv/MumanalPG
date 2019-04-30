
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("ExperienciaLaboral", Schema = "RRHH")]
    public class ExperienciaLaboral
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdExperienciaLaboral { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string NombreInstitucion { get; set; }
        public Int32 IdBeneficiarioClasificacion { get; set; }
        public string Cargo { get; set; }
        public string FuncionGeneral { get; set; }
        public Int32 IdPais { get; set; }
        public string Ciudad { get; set; }
        public string Direccion { get; set; }
        public Decimal TiempoMeses { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinalizacion { get; set; }
        public Boolean PresentoDocumento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
