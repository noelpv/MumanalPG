using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.RRHH;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Models.Finanzas
{
    [Table("Chequera", Schema = "Finanzas")]
    public class Chequera
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdChequera { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Documento de Respaldo")]
        public Int32 IdDocumentoRespaldo { get; set; }
        public DocumentoRespaldo DocumentoRespaldoDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
		[Display(Name="Fecha de Dosificación")]
        public DateTime FechaChequera { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Beneficiario")]
        public Int32 IdBeneficiario { get; set; }
        public Beneficiario BeneficiarioDB {get; set;}
        [NotMapped]
		public string NombreBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "El {0} no es válido")]
        [Display(Name="Correlativo Inicial")]
        public Int32 CorrelativoInicial { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "El {0} no es válido")]
        [Display(Name="Correlativo Final")]
        public Int32 CorrelativoFinal { get; set; }
        [Range(0, Int32.MaxValue, ErrorMessage = "El {0} no es válido")]
        [Display(Name="Correlativo de Chequera")]
        public Int32 CorrelativoCheque { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
		[Display(Name="Fecha Inicial")]
        public DateTime FechaInicial { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
		[Display(Name="Fecha Final")]
        public DateTime FechaFinal { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
		[Display(Name="Fecha Limite")]
        public DateTime FechaLimite { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(255, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Observación")]
        public string Observacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}