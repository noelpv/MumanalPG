using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MumanalPG.Models.Planificacion;

namespace MumanalPG.Models.Finanzas
{
    [Table("CuentaBancaria", Schema = "Finanzas")]
    public class CuentaBancaria
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCuentaBancaria { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Banco")]
        public Int32 IdBanco { get; set; }
        public Banco BancoDB { get;  set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(40, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código de la cuenta")]
        public string CuentaCodigo { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(150, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Descripción")]
        public string Descripcion { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Tipo de Cuenta Bancaria")]
        public Int32 IdTipoCuentaBanco { get; set; }
        public TipoCuentaBanco TipoCuentaBancoDB { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Tipo de Moneda")]
        public Int32 IdTipoMoneda { get; set; }
        public TipoMoneda TipoMonedaDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(10, ErrorMessage = "La longitud máxima es de {1} caracteres")]
		[Display(Name="Código TGN")]
        public string CodigoTgn { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
        [Display(Name="Fecha de Apertura")]
        public DateTime FechaApertura { get; set; }
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar un {0}")]
        [Display(Name="Organismo Financiador")]
        public Int32 IdOrganismoFinanciador { get; set; }
        public OrganismoFinanciador OrganismoFinanciadorDB { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), DataType(DataType.Date)]
        [Display(Name="Fecha de Saldo Inicial")]
        public DateTime FechaSaldoInicial { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Saldo Inicial (Bs)")]
        public Decimal SaldoInicialBs { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Saldo Inicial ($)")]
        public Decimal SaldoInicialDolares { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Ingresos (Bs)")]
        public Decimal IngresosBs { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Ingresos ($)")]
        public Decimal IngresosDolares { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Egresos (Bs)")]
        public Decimal EgresosBs { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Egresos ($)")]
        public Decimal EgresosDolares { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Saldo Actual (Bs)")]
        public Decimal SaldoActualBs { get; set; }
        [Range(0, 7.92e22), DataType(DataType.Currency), Column(TypeName = "decimal(18, 2)")]
        [Display(Name="Saldo Actual ($)")]
        public Decimal SaldoActualDolares { get; set; }
        [Required(ErrorMessage = "{0} no puede estar en blanco"), StringLength(50, ErrorMessage = "La longitud máxima es de {1} caracteres")]
        [Display(Name="Código SIGEP")]
        public string CodigoSigep { get; set; }
        [Display(Name="¿Es cuenta única?")]
        public Boolean EsCuentaUnica { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
