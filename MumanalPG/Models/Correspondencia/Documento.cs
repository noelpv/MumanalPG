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
		public TipoDocumento Tipo { get; set; }
		
		[Required]
		public Int32 Correlativo { get; set; }

		[Required]
		public Int32 Gestion { get; set; }
		
		[Required]
		[StringLength(50)]
		public string Cite { get; set; }

		public int FuncionarioOrigenId { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[DisplayName("De")]
		public virtual Beneficiario FuncionarioOrigen { get; set; }
		
		public int FuncionarioDestinoId { get; set; }
		[Required(ErrorMessage = "{0} no puede estar en blanco")]
		[DisplayName("A")]
		public virtual Beneficiario FuncionarioDestino { get; set; }

		public int FuncionarioViaId { get; set; }
		[DisplayName("VIA")]
		public Beneficiario FuncionarioVia { get; set; }
		
		public int FuncionarioCCId { get; set; }
		[DisplayName("CC")]
		public Beneficiario FuncionarioCC { get; set; }

		[Required]
		[StringLength(50)]
		public string CargoFuncionarioOrigen { get; set; }
		
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
        
		[Required]
		[Column(TypeName = "text")]
		public String Contenido { get; set; }

		public Int32 IdEstadoRegistro { get; set; }
		public Int32 IdUsuario { get; set; }
		public DateTime FechaRegistro { get; set; }
		
	}
}