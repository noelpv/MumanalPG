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

        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public ICollection<Documento> Documentos { get; set; }

        public string shortName()
        {
            string res = "";
            string[] words = Nombre.Split(" ");

            foreach (var word in words)
            {
                res += $"{word.Substring(0,3).ToUpper()}.";
            }

            return res;
        }
    }
}
