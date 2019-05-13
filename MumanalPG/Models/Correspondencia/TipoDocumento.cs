using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.Correspondencia
{
    [Table("TipoDocumento", Schema = "Correspondencia")]
    public class TipoDocumento
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int16 Id { get; set; }

        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(50, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        public String Nombre { get; set; }
        
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(100, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        [Display(Name = "Descripción")]
        public String Descripcion { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        //ACTIVO/INACTIVO/ELIMINADO
        public String Estado { get; set; }
    }
}
