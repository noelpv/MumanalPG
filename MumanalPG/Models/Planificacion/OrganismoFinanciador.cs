using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("OrganismoFinanciador", Schema = "Planificacion")]
	public class OrganismoFinanciador
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdOrganismoFinanciador { get; set; }
		public Int32 IdFuenteFinanciamiento { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public string Gestion { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public string CargoRepresentante { get; set; }
		public Int32 PaisCodigo { get; set; }
		public string EsExterno { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}