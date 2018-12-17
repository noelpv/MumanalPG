using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Models.Ventas
{
	[Table("vContratacion", Schema = "Ventas")]
	public class vContratacion
	{
		[Key]
		public Int32 IdVentaContratacion { get; set; }
		public string Gestion { get; set; }
		public string UnidadEjecutora { get; set; }
		public Int32 CorrelativoUnidad { get; set; }
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime FechaVenta { get; set; }
		public string Beneficiario { get; set; }
		public string Garante { get; set; }
		public string IdAsrSiver { get; set; }
	}
}
