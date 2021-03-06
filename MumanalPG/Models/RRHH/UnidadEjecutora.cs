﻿using System;
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
		public int IdUnidadEjecutoraPadre { get; set; }
		public int? Nivel { get; set; }
		public bool? EsUltimoNivel { get; set; }
		public int? IdMunicipio { get; set; }
		public string Gestion { get; set; }
		public int? IdEstadoRegistro { get; set; }
		public int? IdUsuario { get; set; }
		public DateTime? FechaRegistro { get; set; }
        public decimal? MontoLimite { get; set; }
        public int? CantidadLimite { get; set; }
		
		[InverseProperty("UnidadEjecutora")]
		public ICollection<Puesto> Puestos { get; set; }

		public HojaRuta HojaRuta { get; set; }
		
		[InverseProperty("AreaOrigen")]
		public ICollection<HojaRutaDetalle> Originados { get; set; } 
		
		[InverseProperty("AreaDestino")]
		public ICollection<HojaRutaDetalle> Destinados { get; set; }
		
		public int OrdenMostrar { get; set; }
		public bool EsExterna { get; set; }
	}
}
