using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.Ventas
{
	[Table("vPersona", Schema = "Ventas")]
	public class vPersona
	{
		[Key]
		public Int32 IdBeneficiario { get; set; }
		public string DocumentoIdentidad { get; set; }
		public string Denominacion { get; set; }
	}
}
