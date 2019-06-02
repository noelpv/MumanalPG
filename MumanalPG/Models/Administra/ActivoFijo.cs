using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("ActivoFijo", Schema = "Administra")]
    public class ActivoFijo
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdActivoFijo { get; set; }
        public Int32 IdAlmacenInventario { get; set; }
        public Int32 IdBienes { get; set; }
        public string CodigoActivoFijo { get; set; }
        public string CodigoAdministrativo { get; set; }
        public string Descripcion { get; set; }
        
        public DateTime FechaIncorporacion { get; set; }
        public Decimal Ufv { get; set; }
        public Decimal CostoInicial { get; set; }
        public Decimal DepreciacionAcumuladaInicial { get; set; }
        public Decimal FactorActualizacion { get; set; }
        public Decimal ValorActual { get; set; }
        public Decimal DepreciacionAcumulada { get; set; }
        public Decimal DepreciacionGestion { get; set; }
        public Decimal ValorNeto { get; set; }
        public Int32 TiempoVidaEnAnios { get; set; }
        public Int32 TiempoVidaEnDias { get; set; }
        public string CodigoRube { get; set; }
        public Int32 IdOrganismoFinanciador { get; set; }

        public Int32 Marca { get; set; }
        public Int32 Modelo { get; set; }

        public string Color { get; set; }
        public string Material { get; set; }
        public string Dimensiones { get; set; }
        public string NumeroCajones { get; set; }
        public string TipoBien { get; set; }
        public string ClaseBien { get; set; }
        public string TipoClaseOtro { get; set; }
        public string Procedencia { get; set; }
        public string Capacidad { get; set; }
        public string EquipoAlQuePertenece { get; set; }
        public string AnioFabricacion { get; set; }
        public string Placa { get; set; }
        
        public string Chasis { get; set; }
        public string Motor { get; set; }
        public string Cilindrada { get; set; }
        public string Transmision { get; set; }
        public string Traccion { get; set; }
        public string NumeroPuertas { get; set; }
        public string LlantasAroNumero { get; set; }
        public string RegistroDDRR { get; set; }
        public string RegistroAlcaldia { get; set; }
        public string NumeroPisos { get; set; }
        public string NumeroHabitaciones { get; set; }
        public string Raza { get; set; }
        public string DiscoDuro { get; set; }
        public string Ram { get; set; }
        public string Procesador { get; set; }
        public string Monitor { get; set; }
        public string Teclado { get; set; }
        public string Mouse { get; set; }
        public string OtroNoEstipulado { get; set; }

        public Int32 IdEstadoActivoFijo { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}
