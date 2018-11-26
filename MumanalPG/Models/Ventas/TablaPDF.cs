using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("TablaPDF", Schema = "Ventas")]
	public class TablaPDF
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdTablaPDF { get; set; }
		public Int32 IdDocumento { get; set; }
		public string RutaDocumento { get; set; }
		public Boolean Cargado { get; set; }
	}
}
