using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.Generales;
namespace MumanalPG.Models.Finanzas
{
    [Table("TipoMoneda", Schema = "Finanzas")]
    public class TipoMoneda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdTipoMoneda { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(5, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        public string Sigla { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="País")]
        public Int32 IdPais { get; set; }
        public Pais PaisDB { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}