using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("AsientoTipoGasto", Schema = "Finanzas")]
    public class AsientoTipoGasto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAsientoTipoGasto { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public Int32 IdPartidaInicio { get; set; }
        public Int32 IdPartidaFin { get; set; }
        public Int32 IdPlanCuentasDebe { get; set; }
        public Int32 IdPlanCuentasHaber { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
