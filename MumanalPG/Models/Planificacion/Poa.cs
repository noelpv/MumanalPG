using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("Poa", Schema = "Planificacion")]
	public class Poa
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPoa { get; set; }
		public Int32 IdPoaTarea { get; set; }
		public string Gestion { get; set; }
		public string PoaCodigo { get; set; }
		public string Descripcion { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FechaFinal { get; set; }
		public Int32 IdUnidadNivel3 { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdBeneficiarioResponsable { get; set; }
		public Int32 IdPoaMeta { get; set; }
		public string FuenteVerificacion { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 NumeroRespaldo { get; set; }
		public string CiteRespaldo { get; set; }
		public Int32 Nivel { get; set; }
		public Int32 IdPresupuestoFormulacion { get; set; }
		public Int32 IdPresupuestoFormulacionContraparte { get; set; }
		public string GestionAnterior { get; set; }
		public Int32 IdPoaAnterior { get; set; }
		public string PoaJustificacion { get; set; }
		public Decimal ImporteOrigen { get; set; }
		public Decimal ImporteAdiciones { get; set; }
		public Decimal ImporteModificaciones { get; set; }
		public Decimal ImporteVigenteBolivianos { get; set; }
		public Decimal ImporteVigenteDolares { get; set; }
		public Decimal PorcentajeAvance { get; set; }
		public Decimal PoaPorcentaje { get; set; }
		public Decimal PoaPorcentajeContraparte { get; set; }
		public Decimal EjecucionCompromiso { get; set; }
		public Decimal EjecucionDevengado { get; set; }
		public Decimal EjecucionPagado { get; set; }
		public Decimal EjecucionDevuelto { get; set; }
		public Decimal EjecucionRevertido { get; set; }
		public Decimal EjecucionAnulado { get; set; }
		public string TieneTarea { get; set; }
		public string NombreArchivo { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public string UsuarioCodigoModifica { get; set; }
		public string UsuarioCodigoAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaModifica { get; set; }
		public DateTime FechaAprueba { get; set; }
		public string HoraRegistro { get; set; }
	}
}
