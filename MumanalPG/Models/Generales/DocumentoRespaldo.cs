using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("DocumentoRespaldo", Schema = "Generales")]
	public class DocumentoRespaldo
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdDocumentoRespaldo { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Clasificacion de Documento")]
		public Int32 IdDocumentoClasificacion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Sigla { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Frecuencia de Uso")]
		public Int32 IdFrecuenciaUso { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Formato de Documento")]
		public Int32 IdDocumentoFormato { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Numero de Copias")]
		public Int32 NumeroCopias { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[Display(Name="Lugar Fisico Archivado")]
		public string LugarFisicoArchivado { get; set; }
		[Display(Name="¿Es usado como requisito?")]
		public Boolean EsUsadoComoRequisito { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public int Orden { get; set; }
		[Display(Name="¿Es obligatorio?")]
		public Boolean EsObligatorio { get; set; }
		public int IdProceso { get; set; }
	}
}
