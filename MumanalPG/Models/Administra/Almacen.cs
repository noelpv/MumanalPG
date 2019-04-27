using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("Almacen", Schema = "Administra")]
    public class Almacen
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAlmacen { get; set; }
        public Int32 IdTipoAlmacen { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdMunicipio { get; set; }
        public Int32 IdBarrio { get; set; }
        public Int32 IdCalle { get; set; }
        public string NumeroEdificio { get; set; }
        public string NumeroPiso { get; set; }
        public string NumeroDepartamento { get; set; }
        public string Telefono { get; set; }
        public string Observacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
