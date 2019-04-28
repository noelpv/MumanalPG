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
        public string Descripcion { get; set; }
        public string NombreTabla { get; set; }
        public string NombreCampoCodigo { get; set; }
        public string NombreCampoDescripcion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
