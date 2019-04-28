
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
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public string NIT { get; set; }
        public Int32 IdMunicipio { get; set; }
        public string Direccion { get; set; }
        public string Representante { get; set; }
        public string CargoRepresentante { get; set; }
        public string CodigoPostal { get; set; }
        public Boolean EsReservaFederal { get; set; }
        public string BancoIntermediario { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
