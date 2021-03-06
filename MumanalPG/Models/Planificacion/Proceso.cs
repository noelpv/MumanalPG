﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Planificacion
{
	[Table("Proceso", Schema = "Planificacion")]
	public class Proceso
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdProceso { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public string Descripcion { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdProcesoPadre { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 Nivel { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Boolean EsUltimoNivel { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 NumeroDiasHabiles { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 NumeroDiasCalendario { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdDocumentoRespaldo { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdSistemaFormulario { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}