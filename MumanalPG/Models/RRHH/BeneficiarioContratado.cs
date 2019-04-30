
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("BeneficiarioContratado", Schema = "RRHH")]
    public class BeneficiarioContratado
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdCcargo { get; set; }
        public Int32 IdPuesto { get; set; }
        public Int32 IdCompraContratacionPersona { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public string RegistroProfesional { get; set; }
        public Int32 IdProfesion { get; set; }
        public Int32 ItemRda { get; set; }
        public Int32 ItemRdaJefe { get; set; }
        public Decimal HaberMensual { get; set; }
        public Decimal BonoMensual { get; set; }
        public Decimal OtroSalarioMensual { get; set; }
        public Decimal BonoAntiguedad { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public Int32 IdHorario { get; set; }
        public string NumeroFile { get; set; }
        public Int32 IdEstadoCivil { get; set; }
        public Int32 IdMunicipio { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public string PathArchivoFoto { get; set; }
        public string Observaciones { get; set; }
        public Int32 IdUnidadEducativa { get; set; }
        public Int32 IdPlanillaSubGrupo { get; set; }
        public Boolean EsJubilado { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}