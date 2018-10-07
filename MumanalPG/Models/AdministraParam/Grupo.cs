using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.AdministraParam
{
	[Table("Grupo", Schema = "AdministraParam")]
	public class Grupo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public int IdGrupo { get; set; }
		public String Descripcion { get; set; }
	}
}
