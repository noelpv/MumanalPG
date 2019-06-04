using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.RRHH;
using MumanalPG.Utility;

namespace MumanalPG.Models.Correspondencia
{
	[Table("Documentos", Schema = "Correspondencia")]
	public class Documento
	{
		[DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
		[Key]
		public Int32 Id { get; set; }

		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		public Int16 TipoId { get; set; }
		public TipoDocumento Tipo { get; set; }
		
		public virtual Int32 Correlativo { get; set; }

		public virtual Int32 Gestion { get; set; }
		
		public virtual string Cite { get; set; }

		[Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
		[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Funcionario")]
		[DisplayName("De")]
		public int FuncionarioOrigenId { get; set; }
		public Beneficiario FuncionarioOrigen { get; set; }
		[NotMapped]
		public string NombreOrigen { get; set; }

		[Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
		[Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un Funcionario")]
		[DisplayName("A")]
		public int FuncionarioDestinoId { get; set; }
		public Beneficiario FuncionarioDestino { get; set; }
		[NotMapped]
		public string NombreDestino { get; set; }

		[DisplayName("Vía")]
		public virtual int FuncionarioViaId { get; set; }
		public virtual Beneficiario FuncionarioVia { get; set; }
		[NotMapped]
		public string NombreVia { get; set; }
		
		[DisplayName("CC")]
		public virtual int FuncionarioCCId { get; set; }
		public virtual Beneficiario FuncionarioCC { get; set; }

		public virtual HojaRutaDetalle DerivadoEn { get; set; }

		[NotMapped]
		public string NombreCC { get; set; }

		[Required]
		[StringLength(50)]
		public string CargoFuncionarioOrigen { get; set; }

		[NotMapped]
		public int AreaFuncionarioOrigenId { get; set; }

		[Required]
		[StringLength(50)]
		public string CargoFuncionarioDestino { get; set; }
		
		[StringLength(50)]
		public string CargoFuncionarioVia { get; set; }
		
		[StringLength(50)]
		public string CargoFuncionarioCC { get; set; }
		
		[Required]
		[StringLength(50)]
		public string AreaFuncionarioOrigen { get; set; }
		
		[Required]
		[StringLength(50)]
		public string AreaFuncionarioDestino { get; set; }
		
		[StringLength(50)]
		public string AreaFuncionarioVia { get; set; }
		
		[StringLength(50)]
		public string AreaFuncionarioCC { get; set; }
		

		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[StringLength(100, ErrorMessage = "Longitud máxima es de {1} caracteres")]
		public string Referencia { get; set; }
		
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[DataType(DataType.Date)]
		public DateTime Fecha { get; set; }
        
		[Required(ErrorMessage = "{0} no puede estar vacío")]
		[Column(TypeName = "text")]
		public String Contenido { get; set; }
		
		public HojaRuta HojaRuta { get; set; }

		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		
	}
}