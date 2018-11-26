using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.AdministraParam
{
	[Table("SubGrupo", Schema = "AdministraParam")]
	public class SubGrupo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdSubgrupo { get; set; }
		public string Descripcion { get; set; }
		public Int32 IdGrupo { get; set; }
	}
}