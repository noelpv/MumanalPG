using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Municipio", Schema = "Generales")]
	public class Municipio
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdMunicipio { get; set; }
		public Int32 IdProvincia { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public Int32 Poblacion { get; set; }
		public Int32 IdRegion { get; set; }
		public Int32 GestionCreacion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
