using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace MumanalPG.Models.Correspondencia.DTO
{
    public class HojaRutaPDFDTO
    {
        public HojaRuta hojaRuta { get; set; }
        public HojaRutaDetalle detalle { get; set; }
        
        public List<HojaRutaDetalle> derivaciones { get; set; }
        public List<Instrucciones> instrucciones { get; set; }
        
    }
}