
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.RRHH
{
    [Table("PagoCronogramaDetalle", Schema = "RRHH")]
    public class PagoCronogramaDetalle
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdPagoCronogramaDetalle { get; set; }
        public Int32 IdPagoCronograma { get; set; }
        public Int32 IdBeneficiarioContratado { get; set; }
        public Int32 IdUnidadEjecutora { get; set; }
        public Int32 IdTipoMoneda { get; set; }
        public Decimal IdTipoCambio { get; set; }
        public Decimal SueldoBasico { get; set; }
        public Decimal BonoAntiguedad { get; set; }
        public Decimal Refrigerio { get; set; }
        public Decimal HorasExtras { get; set; }
        public Decimal BonoTransporte { get; set; }
        public Decimal TotalGanado { get; set; }
        public Decimal ProvisionAguinaldo { get; set; }
        public Decimal PrevisionIndemnizacion { get; set; }
        public Decimal AnticipoSueldo { get; set; }
        public Decimal AnticipoRefrigerio { get; set; }
        public Decimal Prestamo { get; set; }
        public Decimal Afp1 { get; set; }
        public Decimal Afp2 { get; set; }
        public Decimal Rciva { get; set; }
        public Decimal OtrosDescuentos { get; set; }
        public Decimal TotalDescuentos { get; set; }
        public Decimal LiquidoPagableDolares { get; set; }
        public Decimal LiquidoPagableBolivianos { get; set; }
        public Boolean EmiteFactura { get; set; }
        public string CiteConformidad { get; set; }
        public DateTime FechaConformidad { get; set; }
        public Int32 OrdenPlanilla { get; set; }
        public Decimal SueldoNeto { get; set; }
        public Decimal MinimoImponible { get; set; }
        public Decimal DiferenciaImpuesto { get; set; }
        public Decimal Impuesto13 { get; set; }
        public Decimal Smn213 { get; set; }
        public Decimal Iva110 { get; set; }
        public Decimal FiscoAFavor { get; set; }
        public Decimal DependienteAFavor { get; set; }
        public Decimal MesAnterior { get; set; }
        public Decimal Actualizacion { get; set; }
        public Decimal Total { get; set; }
        public Decimal MesAnteriorOtro { get; set; }
        public Decimal SaldoUtilidad { get; set; }
        public Decimal SaldoAFavorDependiente { get; set; }
        public Decimal ImpuestoAPagar { get; set; }
        public Decimal SaldoParaMesSiguiente { get; set; }
        public Decimal Ufv1 { get; set; }
        public Decimal Ufv2 { get; set; }
        public DateTime FechaUfv1 { get; set; }
        public DateTime FechaUfv2 { get; set; }
        public Decimal SmnIva { get; set; }
        public Decimal SueldoBasicoAnterior { get; set; }
        public Int32 DiasTrabajados { get; set; }
        public Int32 IdCargo { get; set; }
        public Int32 IdPuesto { get; set; }
        public Decimal HaberMensual { get; set; }
        public DateTime FechaIngreso { get; set; }
        public DateTime FechaExpiracion { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdEstadoDevengado { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
