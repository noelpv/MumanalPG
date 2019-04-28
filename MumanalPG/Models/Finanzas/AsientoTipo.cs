using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("AsientoTipo", Schema = "Finanzas")]
    public class AsientoTipo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAsientoTipo { get; set; }
        public Boolean EsIngresoOGasto { get; set; }
        public Int32 IdTipoComprobante { get; set; }
        public Int32 IdPartidaRubroInicio { get; set; }
        public Int32 IdPartidaRubroFin { get; set; }
        public Int32 IdPlanCuentasDebe { get; set; }
        public Int32 IdPlanCuentasHaber { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
