using System;
using System.ComponentModel.DataAnnotations;

namespace MumanalPG.Models.Ventas
{
	public class pVerificaLimite
	{
		public Decimal MontoLimite { get; set; }
		[Key]
		public Int16	CantidadLimite { get; set; }
	}
}
