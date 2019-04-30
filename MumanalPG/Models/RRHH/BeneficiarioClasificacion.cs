
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("BeneficiarioClasificacion", Schema = "RRHH")]
    public class BeneficiarioClasificacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBeneficiarioClasificacion { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdTipoEntidad { get; set; }
        public Decimal PorcetajeDescuento { get; set; }
        public Int32 IdBeneficiarioInstitucion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}