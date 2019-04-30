
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("ParametroPlanilla", Schema = "RRHH")]
    public class ParametroPlanilla
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdParametroPlanilla { get; set; }
        public string Descripcion { get; set; }
        public Decimal IVA { get; set; }
        public Decimal IT { get; set; }
        public Decimal RCIVA { get; set; }
        public Decimal OtroImpuesto { get; set; }
        public Int32 IdParametroAntiguedad { get; set; }
        public Decimal AporteLaboral { get; set; }
        public Decimal AportePatronal { get; set; }
        public Decimal MinimoNacional { get; set; }
        public Decimal Formulario87 { get; set; }
        public Decimal SueldoMenor65 { get; set; }
        public Decimal SueldoMayor65 { get; set; }
        public Decimal SueldoMenorJuvilado65 { get; set; }
        public Decimal SueldoMayorJuvilado65 { get; set; }
        public Int32 IdVacacionParametro { get; set; }
        public Decimal OtroBono { get; set; }
        public Int32 IdParametroDescuento { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
