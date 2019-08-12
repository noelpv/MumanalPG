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
		[StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		[Display(Name="Tipo de Edificio")]
		public Int32 IdEdificioTipo { get; set; }
		[Display(Name="Municipio")]
		public Int32 IdMunicipio { get; set; }
		[Display(Name="Barrio")]
		public Int32 IdBarrio { get; set; }
		[Display(Name="Calle")]
		public Int32 IdCalle { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Número de Edificio")]
		public String EdificioNumero { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(150, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Referencia Cercana")]
		public String ReferenciaCercana { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Localización Eje X")]
		public Decimal LocalizacionEjeX { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Localización Eje Y")]
		public Decimal LocalizacionEjeY { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(15, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Latitud")]
		public String Latitud { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(15, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Longitud")]
		public String Longitud { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Altitud (m.s.n.m)")]
		public Decimal AltitudSNM { get; set; }
		[Display(Name="Beneficiario")]
		public String IdBeneficiario { get; set; }
		[Display(Name="Beneficiario de la Empresa")]
		public String IdBeneficiarioEmpresa { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Archivo de Foto")]
		public String ArchivoFoto { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(1, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Archivo de Foto Cargado")]
		public Char ArchivoFotoCargado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}