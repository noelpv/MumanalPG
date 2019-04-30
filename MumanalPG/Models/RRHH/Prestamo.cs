
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("Prestamo", Schema = "RRHH")]
    public class Prestamo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPrestamo { get; set; }
        public string Gestion { get; set; }
        public Int32 IdPlanillaSubGrupo { get; set; }
        public Int32 IdDepartamento { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 CorrelativoUnidad { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public string Descripcion { get; set; }
        public Int32 MesInicioCronograma { get; set; }
        public Decimal ImporteBs { get; set; }
        public Decimal ImporteDolares { get; set; }
        public Decimal InteresesBs { get; set; }
        public Decimal InteresesDolares { get; set; }
        public Decimal PrestamoTotalBs { get; set; }
        public Decimal PrestamoTotalDolares { get; set; }
        public Decimal TotalCobradoBs { get; set; }
        public Decimal IdTipoCambio { get; set; }
        public string CiteTramite { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Int32 IdUnidadMedida { get; set; }
        public Int32 CantidadPeriodos { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
