using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("TipoComprobante", Schema = "Finanzas")]
    public class TipoComprobante
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdTipoComprobante { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        public string Sigla { get; set; }
        [Display(Name="¿Es egreso?")]
        public Boolean EsEgreso { get; set; }
        [Display(Name="¿Es ingreso?")]
        public Boolean EsIngreso { get; set; }
        [Display(Name="¿Es de contabilidad?")]
        public Boolean EsContabilidad { get; set; }
        [Display(Name="¿Es cobranza?")]
        public Boolean EsCobranza { get; set; }
        [Display(Name="¿Es pago?")]
        public Boolean EsPago { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}