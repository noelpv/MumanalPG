using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.Correspondencia;


namespace MumanalPG.Models.RRHH
{
	[Table("UnidadEjecutora", Schema = "RRHH")]
	public class UnidadEjecutora
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdUnidadEjecutora { get; set; }
		public string Descripcion { get; set; }
		public string Sigla { get; set; }
		public Int32 IdUnidadEjecutoraPadre { get; set; }
		public Int32 Nivel { get; set; }
		public Boolean EsUltimoNivel { get; set; }
		public Int32 IdMunicipio { get; set; }
		public string Gestion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
        public decimal MontoLimite { get; set; }
        public Int32 CantidadLimite { get; set; }
		
		[InverseProperty("UnidadEjecutora")]
		public ICollection<Puesto> Puestos { get; set; }
    }
}
