using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Auxiliar", Schema = "Finanzas")]
    public class Auxiliar
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAuxiliar { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nombre de la Tabla")]
        public string NombreTabla { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(40, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nombre del Campo de Código")]
        public string NombreCampoCodigo { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(80, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nombre del Campo de Descripción")]
        public string NombreCampoDescripcion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
