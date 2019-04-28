
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Finanzas
{
    [Table("TipoComprobante", Schema = "Finanzas")]
    public class TipoComprobante
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdTipoComprobante { get; set; }
        public string Descripcion { get; set; }
        public string Sigla { get; set; }
        public Boolean EsEgreso { get; set; }
        public Boolean EsIngreso { get; set; }
        public Boolean EsContabilidad { get; set; }
        public Boolean EsCobranza { get; set; }
        public Boolean EsPago { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}