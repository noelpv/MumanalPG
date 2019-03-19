using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("vRequisito", Schema = "Ventas")]
	public class vRequisito
	{
		[Key]
		public Int32 IdVentaRequisito { get; set; }
		public Int32 IdVentaContratacion { get; set; }
		public string Descripcion { get; set; }
		public string PathArchivo { get; set; }
		public Boolean ArchivoCargado { get; set; }
		public Boolean EsObligatorio { get; set; }
		public Int16 Orden { get; set; }
	}
}
