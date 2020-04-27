using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
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
		[DisplayName("CI.")]
		public string DocumentoIdentidad { get; set; }
		[DisplayName("NIT")]
		public string Nit { get; set; }
		public string DepartamentoSigla { get; set; }
		public string Iniciales { get; set; }
		public Int32? IdDocumentoRespaldo { get; set; }
		
		[DisplayName("Apellido Paterno")]
		[Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
		public string PrimerApellido { get; set; }
		[DisplayName("Apellido Materno")]
		public string SegundoApellido { get; set; }
		public string Denominacion { get; set; }
		[DisplayName("Fecha de Nac.")]
		public DateTime? FechaNacimiento { get; set; }
		[DisplayName("Género")]
		public Int32? IdGenero { get; set; }
		[DisplayName("Teléfono")]
		public string TelefonoFijo { get; set; }
		public string TelefonoOficina { get; set; }
		[DisplayName("Celular")]
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
        public Boolean EsHabilitado { get; set; }
        public Int32? IdEstadoRegistro { get; set; }
		public Int32? IdUsuario { get; set; }
		public DateTime? FechaRegistro { get; set; }
		[DisplayName("Primer Nombre")]
		public string PrimerNombre { get; set; }
		[DisplayName("Segundo Nombre")]
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
		
		
		[DisplayName("Puesto de Trabajo")]
		public int PuestoId { get; set; }
		[DisplayName("Puesto de Trabajo")]
		public virtual Puesto Puesto { get; set; }

		[NotMapped] 
		[DisplayName("Area de Trabajo")]
		public int AreaId { get; set; }
		
		[NotMapped] 
		[DisplayName("Nombre de Usuario")]
		[Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
		public string Username { get; set; }
		
		[NotMapped] 
		[EmailAddress]
		[DisplayName("Email")]
		[Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
		public string Email { get; set; }
		
		[NotMapped] 
		[DisplayName("Rol de Usuario")]
		public string RolUsuario { get; set; }

		public virtual ApplicationUser AspNetUser { get; set; }
		
		[InverseProperty("FunOrg")]
		public ICollection<HojaRutaDetalle> Originados { get; set; } 
		
		[InverseProperty("FunDst")]
		public ICollection<HojaRutaDetalle> Destinados { get; set; }

		public string Name()
		{
			string name = $"{PrimerApellido}";
			if (PrimerNombre != null)
			{
				name = $"{name} {PrimerNombre}";
			}else if(SegundoNombre != null){
				name = $"{name} {SegundoNombre}";
			} else if (SegundoApellido != null)
			{
				name = $"{name} {SegundoApellido}";
			}

			return name;
		}

		public static List<SelectListItem> SiglasDepartamentos()
		{
			var siglas = new List<SelectListItem>
			{
				new SelectListItem {Text = "LP", Value = "LP"},
				new SelectListItem {Text = "CB", Value = "CB"},
				new SelectListItem {Text = "SC", Value = "SC"},
				new SelectListItem {Text = "OR", Value = "OR"},
				new SelectListItem {Text = "PT", Value = "PT"},
				new SelectListItem {Text = "CH", Value = "CH"},
				new SelectListItem {Text = "TJ", Value = "TJ"},
				new SelectListItem {Text = "PN", Value = "PN"},
				new SelectListItem {Text = "BN", Value = "BN"}
			};
			return siglas;
		}
	}
}
