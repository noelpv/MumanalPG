using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.RRHH;
using MumanalPG.Models.Generales;

namespace MumanalPG.Models.Administra
{
    [Table("Almacen", Schema = "Administra")]
    public class Almacen
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdAlmacen { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Tipo de Almacen")]
        public Int32 IdTipoAlmacen { get; set; }
        public TipoAlmacen TipoAlmacenDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Descripción")]
        public string Descripcion { get; set; }
        /* Beneficiario es llave foránea - INICIO */
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Beneficiario")]
        public Int32 IdBeneficiario { get; set; }
        // Con la siguiente linea obtenemos los datos de Denominación, Nombre, Apellido, CI, etc segun el IdBeneficiario
        public Beneficiario BeneficiarioDB {get; set;}
        // Para Editar, es necesario tener el nombre del beneficiario, de otro modo al editar el dropdownlist/ajax estara en blanco. Y como no pertenece a la base de datos, se la pone como "no mapeada"
        [NotMapped]
		public string NombreBeneficiario { get; set; }
        /* Beneficiario es llave foránea - FIN*/
        /* Municipio es llave foranea simple - INCIO (Tambien lo es Barrio y Calle)*/
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Municipio")]
        public Int32 IdMunicipio { get; set; }
        public Municipio MunicipioDB { get; set; }
        /* Municipio es llave foranea simple - FIN*/
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Barrio")]
        public Int32 IdBarrio { get; set; }
        public Barrio BarrioDB { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Calle")]
        public Int32 IdCalle { get; set; }
        public Calle CalleDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nro. de Edificio")]
        public string NumeroEdificio { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nro. de Piso")]
        public string NumeroPiso { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Nro. del Departamento")]
        public string NumeroDepartamento { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(40, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Teléfono")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(200, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Observación")]
        public string Observacion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
