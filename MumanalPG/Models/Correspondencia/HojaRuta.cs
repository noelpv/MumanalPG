﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.RRHH;

namespace MumanalPG.Models.Correspondencia
{
	[Table("HojaRuta", Schema = "Correspondencia")]
	public class HojaRuta
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public int Id { get; set; }
		
		[Required]
		public int UnidadEjecutoraId { get; set; }
		public UnidadEjecutora UnidadEjecutora { get; set; }

		[Required]
		public int OrigenId { get; set; }
		public Beneficiario Origen { get; set; }
		
		[Required]
		public int DocumentoId { get; set; }
		public Documento Documento { get; set; }

		[Required]
		public string Referencia { get; set; }

		[Required]
		public string CiteTramite { get; set; } // Cite del documento
		
		[Required]
		public DateTime CiteFecha { get; set; } // Fecha del documento
		
		[Required]
		[Range(1, int.MaxValue)]
		public int NroFojas { get; set; }
		
		[Required]
		public int SolicitudCodigo { get; set; }//correlativo autogenerado por gestion

		[Required]
		public int Gestion { get; set; }

		[Required]
		public string CiteHojaRuta { get; set; }

		public string TipoHojaRuta { get; set; } // INTERNA-EXTERNA

		[Required]
		public string Prioridad { get; set; } // Alta, Media, Baja
		
		public int IdEstadoRegistro { get; set; }
		public int IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
	}
}