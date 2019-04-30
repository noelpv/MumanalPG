
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("Puesto", Schema = "RRHH")]
    public class Puesto
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPuesto { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public string Gestion { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public Int32 IdCargo { get; set; }
        public Int32 Item { get; set; }
        public Boolean Vacante { get; set; }
        public Int32 IdDepartamento { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Boolean EsDePlanilla { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}