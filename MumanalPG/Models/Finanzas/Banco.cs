
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("Banco", Schema = "Finanzas")]
    public class Banco
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBanco { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Sigla { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string NIT { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdMunicipio { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Representante { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string CargoRepresentante { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string CodigoPostal { get; set; }
        public Boolean EsReservaFederal { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string BancoIntermediario { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
