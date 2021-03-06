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
        
        public string[] Anexos { get; set; }
        
        public int Parent { get; set; }
        
        public string TipoHojaRuta { get; set; }

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

        public HojaRuta prepare(int idUsuario, ApplicationDbContext DB)
        {
            HojaRuta hojaRuta = new HojaRuta();
            hojaRuta.UnidadEjecutoraId = UnidadEjecutoraId;
            hojaRuta.OrigenId = OrigenId;
            hojaRuta.Referencia = Referencia;
            hojaRuta.CiteTramite = CiteDoc;
            hojaRuta.CiteFecha = FechaDoc;
            hojaRuta.NroFojas = NroFojas;
            hojaRuta.CiteHojaRuta = $"MUMANAL/CORR.{TipoHojaRuta} ";
            hojaRuta.TipoHojaRuta = TipoHojaRuta;
            hojaRuta.IdEstadoRegistro = Constantes.Enviado;
            hojaRuta.IdUsuario = idUsuario;
            hojaRuta.FechaRegistro = DateTime.Now;
            hojaRuta.Prioridad = Prioridad;
            hojaRuta.DocumentoId = DocumentoId;
            hojaRuta.RemitenteExterno = Remitente;
            hojaRuta.EntidadExterna = UnidadEjecutoraNombre;
            hojaRuta = populateDetalle(hojaRuta, idUsuario, DB);
            hojaRuta = populateAnexos(hojaRuta, idUsuario, DB);
            return hojaRuta;
        }

        public HojaRutaDetalle buildParent(HojaRuta hr, int idUsuario)
        {
            HojaRutaDetalle parent = new HojaRutaDetalle();
            parent.AreaDestinoId = hr.UnidadEjecutoraId;
            parent.AreaOrigenId = hr.UnidadEjecutoraId;
            parent.FunDstId = hr.OrigenId;
            parent.FunOrgId = hr.OrigenId;
            parent.PlazoDias = 1;
            parent.Proveido = "-";
            parent.IdEstadoRegistro = Constantes.Registrado;
            parent.IdUsuario = idUsuario;
            parent.FechaRegistro = DateTime.Now;
            parent.DocumentoId = DocumentoId;
            parent.Padre = -1;
            
            return parent;
        }

        public HojaRuta populateDetalle(HojaRuta hr, int idUsuario, ApplicationDbContext DB)
        {
            ICollection<HojaRutaDetalle> detalle = new List<HojaRutaDetalle>();
            if (hr.Id > 0)
            {
               detalle = hr.Derivaciones; 
            }
            else
            {
                var parentHRDetalle = buildParent(hr, idUsuario);
                detalle.Add(parentHRDetalle);
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

        public HojaRuta populateAnexos(HojaRuta hr, int idUsuario, ApplicationDbContext DB)
        {
            ICollection<Anexo> anexosArray = new List<Anexo>();

            if (hr.Id > 0 && hr.Anexos != null)
            {
                anexosArray = hr.Anexos;
            }

            foreach (var a in Anexos)
            {
                if (a != null)
                {
                    AnexoDTO anexo = JsonConvert.DeserializeObject<AnexoDTO>(a);
                    Anexo an = new Anexo();
                    if (anexo.id != null)
                    {
                        an.Id = Int32.Parse(anexo.id);   
                    }
                    an.HRDetalleId = 0;
                    an.TipoId = anexo.tipoId;
                    an.Descripcion = anexo.descripcion;
                    an.PathArchivo = anexo.path;
                    an.NombreArchivo = anexo.name;
                    an.Size = anexo.size;
                
                    an.IdEstadoRegistro = Constantes.Registrado;
                    an.IdUsuario = idUsuario;
                    an.FechaRegistro = DateTime.Now;
                    anexosArray.Add(an);
                }

            }

            hr.Anexos = anexosArray;
            
            return hr;
        }
        
    }
}