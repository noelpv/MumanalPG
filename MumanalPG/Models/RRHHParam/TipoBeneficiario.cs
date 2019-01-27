using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.RRHHParam
{
	[Table("TipoBeneficiario", Schema = "RRHHParam")]
	public class TipoBeneficiario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int16 IdTipoBeneficiario { get; set; }

		[Required]
		[StringLength(100)]
		public String Denominacion { get; set; }

		[Required]
		public Boolean Activo { get; set; }
	}
}
