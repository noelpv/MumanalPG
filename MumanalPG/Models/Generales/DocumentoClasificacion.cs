using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("DocumentoClasificacion", Schema = "Generales")]
	public class DocumentoClasificacion
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentoClasificacion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(3, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		public string Sigla { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(80, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
