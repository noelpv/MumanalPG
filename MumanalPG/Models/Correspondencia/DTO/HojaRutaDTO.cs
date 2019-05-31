using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MumanalPG.Utility;
using Newtonsoft.Json;
using MumanalPG.Models.Correspondencia;

namespace MumanalPG.Models.Correspondencia.DTO
{
    public class HojaRutaDTO
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Documento")]
        public int DocumentoId { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Remitente")]
        public string Remitente { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Remitente")]
        public int OrigenId { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Entidad/Origen")]
        public int UnidadEjecutoraId { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Entidad/Origen")]
        public string UnidadEjecutoraNombre { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        public string Referencia { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Cite del Documento")]
        public string CiteDoc { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Fecha del Documento")]
        public DateTime FechaDoc { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar ingresar un número válido")]
        [DisplayName("Cantidad de Hojas")]
        public int NroFojas { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        public string Prioridad { get; set; }
        
        [Required(ErrorMessage = "Debe seleccionar almenos una instrucción")]
        public string[] Instrucciones { get; set; }

        public IList<InstruccionDTO> GetInstrucciones()
        {
            IList<InstruccionDTO> list = new List<InstruccionDTO>();
            foreach (var i in Instrucciones)
            {
                InstruccionDTO ins = JsonConvert.DeserializeObject<InstruccionDTO>(i);
                ins.funDstId = Int32.Parse(ins.id.Replace("fun_", ""));
                list.Add(ins);
            }

            return list;
        }

        public HojaRuta prepare(int idUsuario, string tipo = Constantes.HojaRutaInterna)
        {
            HojaRuta hojaRuta = new HojaRuta();
            hojaRuta.UnidadEjecutoraId = UnidadEjecutoraId;
            hojaRuta.OrigenId = OrigenId;
            hojaRuta.Referencia = Referencia;
            hojaRuta.CiteTramite = CiteDoc;
            hojaRuta.CiteFecha = FechaDoc;
            hojaRuta.NroFojas = NroFojas;
            hojaRuta.CiteHojaRuta = $"MUMANAL/CORR.{tipo} ";
            hojaRuta.TipoHojaRuta = tipo;
            hojaRuta.IdEstadoRegistro = Constantes.Registrado;
            hojaRuta.IdUsuario = idUsuario;
            hojaRuta.FechaRegistro = DateTime.Now;
            hojaRuta.Prioridad = Prioridad;
            hojaRuta.DocumentoId = DocumentoId;

            return hojaRuta;
        }
    }
}