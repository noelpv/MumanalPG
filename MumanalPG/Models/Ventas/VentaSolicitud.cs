using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Ventas
{
	[Table("VentaSolicitud", Schema = "Ventas")]
	public class VentaSolicitud
    {
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 IdVentaSolicitud { get; set; } // correlativo general, nose usa para nada mas
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Gestion { get; set; }
        [Display(Name = "Unidad donde Solicita la Afiliación")]
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdUnidadEjecutora { get; set; } //resuelto
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 CorrelativoUnidad { get; set; } // correlativo de la unidad ejecutora
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdDepartamento { get; set; }
        [Display(Name = "Fecha de Afiliación")]
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public DateTime FechaSolicitud { get; set; } = DateTime.Now.Date;
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public DateTime FechaRecepcionSolicitud { get; set; } = DateTime.Now.Date;
        [Display(Name = "Persona a ser Afiliada")]
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdBeneficiario { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdBeneficiarioResponsable { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Descripcion { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string Observaciones { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string CiteTramite { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 MesNumero { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdPoa { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdProceso { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 IdDocumentoRespaldo { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public Int32 NumeroDocumento { get; set; }
        //[Required(ErrorMessage = "{0} no puede estar en blanco")]
        public string PathArchivo { get; set; }
        public Boolean ArchivoCargado { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public Int32 IdUsuarioAprueba { get; set; }
		public DateTime FechaRegistro { get; set; }
		public DateTime FechaAprueba { get; set; }
	}
}
