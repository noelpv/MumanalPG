﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("RubroIngreso", Schema = "Planificacion")]
	public class RubroIngreso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdRubroIngreso { get; set; }
        public string Descripcion { get; set; }
        public Int32 IdRubroIngresoPadre { get; set; }
        public Int32 Nivel { get; set; }
        public Boolean EsUltimoNivel { get; set; }
        public string Gestion { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}