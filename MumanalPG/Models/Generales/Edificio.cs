using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Edificio", Schema = "Generales")]
	public class Edificio
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdEdificio { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public String Descripcion { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Tipo de Edificio")]
		public Int32 IdEdificioTipo { get; set; }
		public EdificioTipo EdificioTipoDB { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Municipio")]
		public Int32 IdMunicipio { get; set; }
		public Municipio MunicipioDB { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Barrio")]
		public Int32 IdBarrio { get; set; }
		public Barrio BarrioDB { get; set; }
		[Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Calle")]
		public Int32 IdCalle { get; set; }
		public Calle CalleDB { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Número de Edificio")]
		public String EdificioNumero { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(150, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Referencia Cercana")]
		public String ReferenciaCercana { get; set; }
		[Range(-7.92e22, 7.92e22, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Localización Eje X")]
		public Decimal LocalizacionEjeX { get; set; }
		[Range(-7.92e22, 7.92e22, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Localización Eje Y")]
		public Decimal LocalizacionEjeY { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(15, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Latitud")]
		public String Latitud { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(15, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Longitud")]
		public String Longitud { get; set; }
		[Range(-7.92e22, 7.92e22, ErrorMessage = "Debe seleccionar un {0}")]
		[Display(Name="Altitud (m.s.n.m)")]
		public Decimal AltitudSNM { get; set; }
		[Display(Name="Beneficiario")]
		public String IdBeneficiario { get; set; }
		[Display(Name="Beneficiario de la Empresa")]
		public String IdBeneficiarioEmpresa { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Archivo de Foto")]
		public String ArchivoFoto { get; set; }
		//[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(1, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Archivo de Foto Cargado")]
		public String ArchivoFotoCargado { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}