
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PrestamoProgramacion", Schema = "RRHH")]
    public class PrestamoProgramacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPrestamoProgramacion { get; set; }
        public Int32 IdPrestamo { get; set; }
        public string Gestion { get; set; }
        public Int32 MesControl { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public Decimal ProgramadoBs { get; set; }
        public Decimal ProgramadoDolares { get; set; }
        public Decimal DescuentoBs { get; set; }
        public Decimal DescuentoDolares { get; set; }
        public Decimal TotalProgramadoBs { get; set; }
        public Decimal TotalProgramadoDolares { get; set; }
        public DateTime FechaProgramada { get; set; }
        public DateTime FechaDeCobro { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdTipoTransaccion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
