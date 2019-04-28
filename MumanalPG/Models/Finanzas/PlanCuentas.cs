
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("PlanCuentas", Schema = "Finanzas")]
    public class PlanCuentas
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPlanCuentas { get; set; }
        public string Cuenta { get; set; }
        public string SubCuenta1 { get; set; }
        public string SubCuenta2 { get; set; }
        public string NombreCuenta { get; set; }
        public Int32 IdAuxiliar1 { get; set; }
        public Int32 IdAuxiliar2 { get; set; }
        public Int32 IdAuxiliar3 { get; set; }
        public Int32 IdPlanCuentasPadre { get; set; }
        public Boolean EsDeMovimiento { get; set; }
        public Int32 IdTipoCuenta { get; set; }
        public Int32 Nivel { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
