using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.RRHH;

namespace MumanalPG.Models.Correspondencia
{
	[Table("HojaRutaDetalle", Schema = "Correspondencia")]
	public class HojaRutaDetalle
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		
		[Required]
		public int HojaRutaId { get; set; }
		public HojaRuta HojaRuta { get; set; }
		
		[Required]
		public int AreaOrigenId { get; set; }
		public UnidadEjecutora AreaOrigen { get; set; }
		
		[Required]
		public int AreaDestinoId { get; set; }
		public UnidadEjecutora AreaDestino { get; set; }
		
		[Required]
		public int FunOrgId { get; set; }
		public Beneficiario FunOrg { get; set; }
		
		[Required]
		public int FunDstId { get; set; }
		public Beneficiario FunDst { get; set; }
		
		public ICollection<HRDetalleInstrucciones> HRDetalleInstrucciones { get; set; }
		
		[Required]
		public int PlazoDias { get; set; }
		
		[Required]
		public string Proveido { get; set; }
		
		public bool Leido { get; set; }
		public DateTime? FechaRecepcion { get; set; }
		
		public int Padre { get; set; }

		public int DocumentoId { get; set; }
		public virtual Documento Documento { get; set; }

		public int IdEstadoRegistro { get; set; }
		public int IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }

	}
}