﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Generales
{
	[Table("Provincia", Schema = "Generales")]
	public class Provincia
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdProvincia { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdDepartamento { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Sigla { get; set; }
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}
