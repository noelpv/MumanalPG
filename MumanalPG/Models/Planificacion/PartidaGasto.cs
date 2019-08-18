using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("PartidaGasto", Schema = "Planificacion")]
	public class PartidaGasto
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
        [Display(Name = "Codigo")]
        public Int32 IdPartidaGasto { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [StringLength(50, ErrorMessage = "Longitud máxima es de {1} caracteres")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdPartidaGastoPadre { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 Nivel { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Boolean EsUltimoNivel { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Gestion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 VidaUtil { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 CoeficienteDepreciacion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
