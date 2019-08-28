using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("PlanCuentas", Schema = "Finanzas")]
    public class PlanCuentas
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPlanCuentas { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Cuenta")]
        public string Cuenta { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(3, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Sub-Cuenta 1")]
        public string SubCuenta1 { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(3, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Sub-Cuenta 2")]
        public string SubCuenta2 { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(200, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nombre de Cuenta")]
        public string NombreCuenta { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [Display(Name="Auxiliar 1")]
        public Int32 IdAuxiliar1 { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [Display(Name="Auxiliar 2")]
        public Int32 IdAuxiliar2 { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [Display(Name="Auxiliar 3")]
        public Int32 IdAuxiliar3 { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), Display(Name="Plan de Cuentas Padre")]
        public Int32 IdPlanCuentasPadre { get; set; }
        [Display(Name="¿Estado de movimiento?")]
        public Boolean EsDeMovimiento { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), Display(Name="Tipo Cuenta")]
        public Int32 IdTipoCuenta { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), Range(0, 1000, ErrorMessage = "El {0} no es válido")]
        public Int32 Nivel { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
