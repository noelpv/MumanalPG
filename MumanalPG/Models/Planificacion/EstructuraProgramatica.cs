using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("EstructuraProgramatica", Schema = "Planificacion")]
	public class EstructuraProgramatica
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdEstructuraProgramatica { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(50, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(5, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        public string Sigla { get; set; }
		public string CodigoSisin { get; set; }
		public string Nivel { get; set; }
		public string Gestion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
