using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("AsientoTipoIngreso", Schema = "Finanzas")]
    public class AsientoTipoIngreso
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAsientoTipoIngreso { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public Int32 IdRubroInicio { get; set; }
        public Int32 IdRubroFin { get; set; }
        public Int32 IdPlanCuentasDebe { get; set; }
        public Int32 IdPlanCuentasHaber { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
