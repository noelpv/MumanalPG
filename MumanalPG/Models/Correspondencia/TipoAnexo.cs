using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Correspondencia
{
	[Table("TiposAnexo", Schema = "Correspondencia")]
	public class TipoAnexo
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 Id { get; set; }
		
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(50, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		public String Nombre { get; set; }
        
		[StringLength(100, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		[Display(Name = "Descripción")]
		public String Descripcion { get; set; }

		public ICollection<Anexo> Anexos { get; set; }
		
		public int IdEstadoRegistro { get; set; }
		public int IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}