
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("ContabilidadDetalle", Schema = "Finanzas")]
    public class ContabilidadDetalle
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdContabilidadDetalle { get; set; }
        public Int32 IdContabilidad { get; set; }
        public Int32 IdAsientoTipo { get; set; }
        public Int32 DebeAuxiliar1 { get; set; }
        public Int32 DebeAuxiliar2 { get; set; }
        public Int32 DebeAuxiliar3 { get; set; }
        public Int32 HaberAuxiliar1 { get; set; }
        public Int32 HaberAuxiliar2 { get; set; }
        public Int32 HaberAuxiliar3 { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
