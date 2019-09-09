using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("DocumentoFormato", Schema = "Generales")]
	public class DocumentoFormato
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentoFormato { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(30, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
		public string Descripcion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
