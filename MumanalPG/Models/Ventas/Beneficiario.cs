using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("Beneficiario", Schema = "Ventas")]
	public class Beneficiario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdBeneficiarioClasificacion { get; set; }
		public string DocumentoIdentidad { get; set; }
		public string Nit { get; set; }
		public string DepartamentoSigla { get; set; }
		public string Iniciales { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
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
		public Boolean EsDeudor { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}