using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Correspondencia
{
	[Table("Anexos", Schema = "Correspondencia")]
	public class Anexo
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 Id { get; set; }
       
		[StringLength(200, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		[Display(Name = "Descripción")]
		public string Descripcion { get; set; }
		
		[Display(Name = "Archivo")]
		public string PathArchivo { get; set; }

		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public int TipoId { get; set; }
		public TipoAnexo Tipo { get; set; }
		
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public int HRDetalleId { get; set; }
		public HojaRutaDetalle HRDetalle { get; set; }
		
		public int HojaRutaId { get; set; }
		public HojaRuta HojaRuta { get; set; }
		
		public int IdEstadoRegistro { get; set; }
		public int IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}