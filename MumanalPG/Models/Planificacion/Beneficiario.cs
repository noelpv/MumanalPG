using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("Beneficiario", Schema = "Planificacion")]
	public class Beneficiario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdBeneficiario { get; set; }
		public string BeneficiarioCodigo { get; set; }
		public string DeptoSigla { get; set; }
		public string BeneficiarioIniciales { get; set; }
		public string TipodocCodigo { get; set; }
		public Int32 TipobenCodigo { get; set; }
		public string BeneficiarioNit { get; set; }
		public string PrimerApellido { get; set; }
		public string SegundoApellido { get; set; }
		public string Nombres { get; set; }
		public string Denominacion { get; set; }
		public DateTime FechaNacimiento { get; set; }
		public string TelefonoFijo { get; set; }
		public string TelefonoOficina { get; set; }
		public string TelefonoCelular { get; set; }
		public string EmailPersonal { get; set; }
		public string EmailOficina { get; set; }
		public string DomicilioLegal { get; set; }
		public Int32 IdMunicipio { get; set; }
		public Int32 IdZona { get; set; }
		public Int32 IdCalle { get; set; }
		public Int32 IdEdificio { get; set; }
		public string EdificioNumero { get; set; }
		public string EdificioNumeroPiso { get; set; }
		public string EdificioNumeroDepto { get; set; }
		public string EsDeudor { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
