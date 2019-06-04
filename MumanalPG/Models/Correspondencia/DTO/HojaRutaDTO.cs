using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using MumanalPG.Data;
using MumanalPG.Utility;
using Newtonsoft.Json;
using MumanalPG.Models.Correspondencia;

namespace MumanalPG.Models.Correspondencia.DTO
{
    public class HojaRutaDTO
    {
        //protected ApplicationDbContext DB { get; }
        
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El campo '{0}' no puede estar en blanco")]
        [DisplayName("Documento")]
        public int DocumentoId { get; set; }
        
        public int HojaRutaId { get; set; }
        
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
        
        public int Parent { get; set; }

        public IList<InstruccionDTO> GetInstrucciones()
        {
            IList<InstruccionDTO> list = new List<InstruccionDTO>();
            foreach (var i in Instrucciones)
            {
                InstruccionDTO ins = JsonConvert.DeserializeObject<InstruccionDTO>(i);
                list.Add(ins);
            }

            return list;
        }

        public HojaRuta prepare(int idUsuario, ApplicationDbContext DB, string tipo = Constantes.HojaRutaInterna)
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
            hojaRuta.IdEstadoRegistro = Constantes.Enviado;
            hojaRuta.IdUsuario = idUsuario;
            hojaRuta.FechaRegistro = DateTime.Now;
            hojaRuta.Prioridad = Prioridad;
            hojaRuta.DocumentoId = DocumentoId;
            hojaRuta = populateDetalle(hojaRuta, idUsuario, DB);
            return hojaRuta;
        }

        public HojaRuta populateDetalle(HojaRuta hr, int idUsuario, ApplicationDbContext DB)
        {
            ICollection<HojaRutaDetalle> detalle = new List<HojaRutaDetalle>();
            if (hr.Id > 0)
            {
               detalle = hr.Derivaciones; 
            }

            foreach (var i in Instrucciones)
            {
                InstruccionDTO ins = JsonConvert.DeserializeObject<InstruccionDTO>(i);
                ICollection<HRDetalleInstrucciones> listDetIns = new List<HRDetalleInstrucciones>();
                HojaRutaDetalle d = new HojaRutaDetalle();
                d.AreaDestinoId = ins.areaId;
                d.AreaOrigenId = UnidadEjecutoraId;
                d.FunDstId = ins.funId;
                d.FunOrgId = OrigenId;
                d.PlazoDias = 1;
                d.Proveido = (ins.comentarios != null) ? ins.comentarios : "-";
                d.IdEstadoRegistro = Constantes.Registrado;
                d.IdUsuario = idUsuario;
                d.FechaRegistro = DateTime.Now;
                d.DocumentoId = DocumentoId;
                d.Padre = Parent;
                foreach (var id in ins.instrucciones)
                {
                    Instrucciones instruccion = DB.CorrespondenciaInstrucciones.Find(id);

                    if (instruccion != null)
                    {
                        HRDetalleInstrucciones DetIns = new HRDetalleInstrucciones();
                        DetIns.HRDetalle = d;
                        DetIns.Instruccion = instruccion;
                        listDetIns.Add(DetIns);  
                    }
                }

                d.HRDetalleInstrucciones = listDetIns;
                detalle.Add(d);
            }

            hr.Derivaciones = detalle;
            return hr;
        }
    }
}