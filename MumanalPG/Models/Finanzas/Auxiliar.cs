using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Auxiliar", Schema = "Finanzas")]
    public class Auxiliar
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAuxiliar { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string NombreTabla { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string NombreCampoCodigo { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string NombreCampoDescripcion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
