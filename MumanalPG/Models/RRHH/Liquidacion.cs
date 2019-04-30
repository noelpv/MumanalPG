
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("Liquidacion", Schema = "RRHH")]
    public class Liquidacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdLiquidacion { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public string GestionInicial { get; set; }
        public string Gestion { get; set; }
        public Int32 IdCompraContratacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaRetiro { get; set; }
        public Int32 IdMotivoProceso { get; set; }
        public Int32 IdMemoranda { get; set; }
        public Decimal MontoMensual { get; set; }
        public Int32 Anios { get; set; }
        public Int32 Meses { get; set; }
        public Int32 Dias { get; set; }
        public string MesAntepenultimo { get; set; }
        public string MesPenultimo { get; set; }
        public string MesUtimo { get; set; }
        public Decimal PagoAntepenultimo { get; set; }
        public Decimal PagoPenultimo { get; set; }
        public Decimal PagoUtimo { get; set; }
        public Decimal OtroPagoAntepenultimo { get; set; }
        public Decimal OtroPagoPenultimo { get; set; }
        public Decimal OtroPagoUtimo { get; set; }
        public Decimal Desahucio3Meses { get; set; }
        public Decimal ImdemnizacionAño { get; set; }
        public Decimal ImdemnizacionMes { get; set; }
        public Decimal ImdemnizacionDias { get; set; }
        public Decimal AguinaldoNavidad { get; set; }
        public Decimal AguinaldoVacacion { get; set; }
        public Decimal PrimaLegal { get; set; }
        public Decimal OtrosPagos { get; set; }
        public Int32 IdCuentaBancaria { get; set; }
        public Decimal Deducciones { get; set; }
        public string FormaPago { get; set; }
        public string NumeroChequeOCmpbte { get; set; }
        public Decimal MontoTotal { get; set; }
        public DateTime FechaLiquidacion { get; set; }
        public string PathArchivo { get; set; }
        public Boolean ArchivoCargado { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
