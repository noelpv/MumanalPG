
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("TipoAlmacen", Schema = "Administra")]
    public class TipoAlmacen
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        [Display(Name = "Tipo Almacen")]
        public Int32 IdTipoAlmacen { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Descripcion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}