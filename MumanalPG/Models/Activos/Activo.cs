using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Activos
{
	public class Activo
	{
		[Key]
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		public Int32 ActivoId { get; set; }
		public String Codigo { get; set; }
		public String Descripcion { get; set; }
	}
}
