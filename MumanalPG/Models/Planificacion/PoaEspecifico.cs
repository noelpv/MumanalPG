using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PoaEspecifico", Schema = "Planificacion")]
	public class PoaEspecifico
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdPoaEspecifico { get; set; }
		public Int32 IdPoaEstrategico { get; set; }
		public string Gestion { get; set; }
		public string PoaCodigo { get; set; }
		public string PoaDescripcion { get; set; }
		public DateTime FechaInicio { get; set; }
		public DateTime FichaFinal { get; set; }
		public Int32 IdUnidadNivel3 { get; set; }
		public Int32 IdBeneficiario { get; set; }
		public Int32 IdBeneficiarioResponsable { get; set; }
		public Int32 IdPoaMeta { get; set; }
		public string FuenteVerificacion { get; set; }
		public Int32 IdEstructuraProgramatica { get; set; }
		public Int32 IdDocumentoRespaldo { get; set; }
		public Int32 NumeroRespaldo { get; set; }
		public string CiteRespaldo { get; set; }
		public Int32 Nivel { get; set; }
		public Int32 IdPoaActividadAnterior { get; set; }
		public string GestionAnterior { get; set; }
		public string PoaJustificacion { get; set; }
		public Decimal ImporteOrigen { get; set; }
		public Decimal ImporteAdiciones { get; set; }
		public Decimal ImporteModificaciones { get; set; }
		public Decimal ImporteVigenteBolivianos { get; set; }
		public Decimal ImporteVigenteDolares { get; set; }
		public string EstadoCodigo { get; set; }
		public string UsuarioCodigo { get; set; }
		public string UsuarioCodigoAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}