using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Administra
{
    [Table("CompraContratacion", Schema = "Administra")]
    public class CompraContratacion
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public Int32 IdCompraContratacion { get; set; }
        public Int32 IdCompraSolicitud { get; set; }
        public string Gestion { get; set; }
        public DateTime FechaCompra { get; set; }
        public Int32 IdBeneficiario { get; set; }
        public Int32 IdBeneficiarioResponsable { get; set; }
        public string Concepto { get; set; }
        public string Observaciones { get; set; }
        public string CiteTramite { get; set; }
        public Int32 IdModalidadContratacion { get; set; }
        public Int32 MesNumero { get; set; }
        public Int32 IdDepartamento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public Int32 IdPoa { get; set; }
        public Int32 IdProceso { get; set; }
        public Int32 IdDocumentoRespaldo { get; set; }
        public Int32 NumeroDocumento { get; set; }
        public string ArchivoRespaldo { get; set; }
        public Boolean ArchivoRespaldoCargado { get; set; }
        public Int32 IdEstadoRegistro { get; set; }
        public Int32 IdUsuario { get; set; }
        public Int32 IdUsuarioAprueba { get; set; }
        public DateTime FechaRegistro { get; set; }
        public DateTime FechaAprueba { get; set; }
    }
}
