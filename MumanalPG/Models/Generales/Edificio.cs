using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Edificio", Schema = "Generales")]
	public class Edificio
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdEdificio { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		[Display(Name="Tipo de Edificio")]
		public Int32 IdEdificioTipo { get; set; }
		[Display(Name="Municipio")]
		public Int32 IdMunicipio { get; set; }
		[Display(Name="Barrio")]
		public Int32 IdBarrio { get; set; }
		[Display(Name="Calle")]
		public Int32 IdCalle { get; set; }
		public String EdificioNumero { get; set; }
		public String ReferenciaCercana { get; set; }
		public Decimal LocalizacionEjeX { get; set; }
		public Decimal LocalizacionEjeY { get; set; }
		public String Latitud { get; set; }
		public String Longitud { get; set; }
		public Decimal AltitudSNM { get; set; }
		[Display(Name="Beneficiario")]
		public String IdBeneficiario { get; set; }
		public String IdBeneficiarioEmpresa { get; set; }
		[Display(Name="Archivo de Foto")]
		public String ArchivoFoto { get; set; }
		[Display(Name="Archivo de Foto Cargado")]
		public Char ArchivoFotoCargado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}