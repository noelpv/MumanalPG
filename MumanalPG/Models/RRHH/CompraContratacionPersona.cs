
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("CompraContratacionPersona", Schema = "RRHH")]
    public class CompraContratacionPersona
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraContratacionPersona { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public string CiteTramite { get; set; }
        public Int32 IdPuesto { get; set; }
        public Int32 IdCargo { get; set; }
        public Int32 IdMunicipio { get; set; }
        public Int32 IdNivelEducativo { get; set; }
        public Int32 IdProfesion { get; set; }
        public Int32 IdGenero { get; set; }
        public Int32 IdEstadoCivil { get; set; }
        public Int32 IdModalidadContratacion { get; set; }
        public Int32 IdMetodoSeleccion { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Decimal TotalContratoBolivianos { get; set; }
        public Decimal TotalContratoDolares { get; set; }
        public Decimal HaberMensualBolivianos { get; set; }
        public Decimal HaberMensualDolares { get; set; }
        public Decimal OtroSueldoBolivianos { get; set; }
        public Decimal OtroSueldoDolares { get; set; }
        public Decimal TiempoEnMeses { get; set; }
        public string Observaciones { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public DateTime FechaContrato { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public Int32 IdPlanillaGrupo { get; set; }
        public Int32 IdPlanillaSubgrupo { get; set; }
        public Boolean EsJubilado { get; set; }
        public Int32 Item { get; set; }
        public string ItemJefe { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public Int32 IdHorario { get; set; }
        public string NumeroFile { get; set; }
        public Int32 IdMotivoProceso { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
