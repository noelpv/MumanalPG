﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("SistemaFormulario", Schema = "Generales")]
	public class SistemaFormulario
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdSistemaFormulario { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public String NombreObjeto { get; set; }
		[Display(Name="Menu de Sistema")]
		public Int32 IdSistemaMenu { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}