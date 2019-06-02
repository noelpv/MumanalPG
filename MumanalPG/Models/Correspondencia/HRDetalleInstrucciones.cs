using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MumanalPG.Models.Correspondencia
{
    [Table("HRDetalleInstrucciones", Schema = "Correspondencia")]
    public class HRDetalleInstrucciones
    {
        [DatabaseGenerated(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        
        public int HRDetalleId { get; set; }
        public HojaRutaDetalle HRDetalle { get; set; }
        
        public int InstruccionId { get; set; }
        public Instrucciones Instruccion { get; set; }
        
    }
}