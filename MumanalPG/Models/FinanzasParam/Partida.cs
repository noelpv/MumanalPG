using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.FinanzasParam
{
	[Table("Partida", Schema = "FinanzasParam")]
	public class Partida
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public int IdPartida { get; set; }
		public Int16 IdSubGrupo { get; set; }
		public String Descripcion { get; set; }
		public Int32 Gestion { get; set; }
		public Int16 VidaUtil { get; set; }
	}
}
