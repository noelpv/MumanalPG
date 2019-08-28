using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.Generales;
namespace MumanalPG.Models.Finanzas
{
    [Table("Banco", Schema = "Finanzas")]
    public class Banco
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdBanco { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es d {1} caracteres")]
        public string Sigla { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        public string NIT { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Municipio")]
        public Int32 IdMunicipio { get; set; }
        public Municipio MunicipioDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        public string Representante { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(100, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Cargo del representante")]
        public string CargoRepresentante { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(20, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Código Postal")]
        public string CodigoPostal { get; set; }
        [Display(Name="¿Es Reserva Federal?")]
        public Boolean EsReservaFederal { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Banco Intermediario")]
        public string BancoIntermediario { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(200, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        public string Observaciones { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
