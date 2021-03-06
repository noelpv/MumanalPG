﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models;
using MumanalPG.Utility;

namespace MumanalPG.Models.Planificacion
{
	[Table("RubroIngreso", Schema = "Planificacion")]
	public class RubroIngreso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
        [Display(Name = "Codigo")]
        public Int32 IdRubroIngreso { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        [DisplayName("Rubro Padre")]
        public Int32 IdRubroIngresoPadre { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 Nivel { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Boolean EsUltimoNivel { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Gestion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
