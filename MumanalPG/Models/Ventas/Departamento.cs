using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("Departamento", Schema = "Ventas")]
	public class Departamento
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDepartamento { get; set; }
		public Int32 IdPais { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}