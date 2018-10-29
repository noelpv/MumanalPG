using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("UnidadVsResponsable", Schema = "Planificacion")]
	public class UnidadVsResponsable
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdUnidadVsResponsable { get; set; }
		public Int32 IdUnidadNivel3 { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public string EsJefe { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}


