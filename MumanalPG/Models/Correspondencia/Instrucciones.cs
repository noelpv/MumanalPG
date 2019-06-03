using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Correspondencia
{
	[Table("Instrucciones", Schema = "Correspondencia")]
	public class Instrucciones
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 Id { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(50, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		public String Nombre { get; set; }
        
		[StringLength(100, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		[Display(Name = "Descripción")]
		public String Descripcion { get; set; }

		public ICollection<HRDetalleInstrucciones> HRDetalleInstrucciones { get; set; }
		
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}