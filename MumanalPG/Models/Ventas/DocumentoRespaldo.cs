using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("DocumentoRespaldo", Schema = "Ventas")]
	public class DocumentoRespaldo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentoRespaldo { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Clasificación de Documento")]
		public Int32 IdDocumentoClasificacion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(6, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		public string Sigla { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Frecuencia de Uso")]
		public Int32 IdFrecuenciaUso { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Formato de Documento")]
		public Int32 IdDocumentoFormato { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Range(0, Int32.MaxValue, ErrorMessage="El máximo admitido es: {2}")]
		[Display(Name="Número de Copias")]
		public Int32 NumeroCopias { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Lugar Fisico Archivado")]
		public string LugarFisicoArchivado { get; set; }
		[Display(Name="¿Es usado como requisito?")]
		public Boolean EsUsadoComoRequisito { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Range(0, Int32.MaxValue, ErrorMessage = "No es un número válido")]
		public Int32 Orden { get; set; }
		[Display(Name="¿Es obligatorio?")]
		public Boolean EsObligatorio { get; set; }
		//public Int32 IdProceso { get; set; }
	}
}
