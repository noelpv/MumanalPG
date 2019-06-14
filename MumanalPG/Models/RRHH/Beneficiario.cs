using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.Correspondencia;


namespace MumanalPG.Models.RRHH
{
	[Table("Beneficiario", Schema = "RRHH")]
	public class Beneficiario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdBeneficiario { get; set; }
		public Int32? IdBeneficiarioClasificacion { get; set; }
		public string DocumentoIdentidad { get; set; }
		public string Nit { get; set; }
		public string DepartamentoSigla { get; set; }
		public string Iniciales { get; set; }
		public Int32? IdDocumentoRespaldo { get; set; }
		public string PrimerApellido { get; set; }
		public string SegundoApellido { get; set; }
		public string Denominacion { get; set; }
		public DateTime? FechaNacimiento { get; set; }
        public Int32? IdGenero { get; set; }
        public string TelefonoFijo { get; set; }
		public string TelefonoOficina { get; set; }
		public string TelefonoCelular { get; set; }
		public string EmailPersonal { get; set; }
		public string EmailOficina { get; set; }
		public string DomicilioLegal { get; set; }
		public Int32? IdMunicipio { get; set; }
        public Int32? IdBarrio { get; set; }
        public Int32? IdCalle { get; set; }
		public Int32? IdEdificio { get; set; }
		public string EdificioNumero { get; set; }
		public string EdificioNumeroPiso { get; set; }
		public string EdificioNumeroDepto { get; set; }
		public string EsDeudor { get; set; }
		public Int32? IdEstadoRegistro { get; set; }
		public Int32? IdUsuario { get; set; }
		public DateTime? FechaRegistro { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string ApellidoCasada { get; set; }

        [InverseProperty("FuncionarioOrigen")]
		public ICollection<Documento> DocumentosCreados { get; set; }
		
		[InverseProperty("FuncionarioDestino")]
		public ICollection<Documento> DocumentosRecibidos { get; set; }
		
		[InverseProperty("FuncionarioVia")]
		public ICollection<Documento> DocumentosVia { get; set; }
		
		[InverseProperty("FuncionarioCC")]
		public ICollection<Documento> DocumentosCC { get; set; }
		
		[InverseProperty("Origen")]
		public ICollection<HojaRuta> HojasRuta { get; set; }
		
		
		public int PuestoId { get; set; }
		[DisplayName("Puesto de Trabajo")]
		public virtual Puesto Puesto { get; set; }
		
		public virtual ApplicationUser AspNetUser { get; set; }
		
		[InverseProperty("FunOrg")]
		public ICollection<HojaRutaDetalle> Originados { get; set; } 
		
		[InverseProperty("FunDst")]
		public ICollection<HojaRutaDetalle> Destinados { get; set; } 
	}
}
