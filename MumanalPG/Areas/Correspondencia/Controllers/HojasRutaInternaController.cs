using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Models.Correspondencia;
using MumanalPG.Models.Correspondencia.DTO;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class HojasRutaInternaController : BaseController
    {        
        public const  string RedirectHRCreate = "HRCREATE";
        public const  string RedirectHRSent = "HRSENT";
        private readonly IHostingEnvironment hostingEnvironment;
        
        public HojasRutaInternaController(ApplicationDbContext db, UserManager<IdentityUser> userManager, IHostingEnvironment environment): base(db, userManager)
        {
            hostingEnvironment = environment; 
        }
        
        [Breadcrumb("Bandeja de Entrada", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, string type, string typeHR, int page = 1, string sortExpression = "-FechaRegistro", string a = "")
        {
            
            var consulta = DB.CorrespondenciaHRDetalle.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.AreaOrigen)
                               .Include(m => m.AreaDestino)
                               .Include(m => m.FunOrg)
                               .Include(m => m.FunDst)
                               .Include(m => m.HojaRuta)
                               .Where(m => (m.Id > 0 && m.Padre > 0));


            if (typeHR != null)
            {
                consulta = consulta.Where(m => m.HojaRuta.TipoHojaRuta == typeHR);
            }

            if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.HojaRuta.Referencia, $"%{filter}%"));
            }
            
            ApplicationUser currentUser = await GetCurrentUser();
            switch (type)
            {
                case Constantes.HRTipoUrgentes:
                    consulta = consulta.Where(m => m.HojaRuta.Prioridad == Constantes.PrioridadUrgente &&
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado && 
                                                   m.IdEstadoRegistro == Constantes.Registrado);
                    if (!User.IsInRole(SD.SuperAdminEndUser))
                    {
                        consulta = consulta.Where(m => m.FunDstId == currentUser.Funcionario.IdBeneficiario);  
                    }

                    
                    break;
                case Constantes.HRTipoDespachados:
                    consulta = consulta.Where(m => m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado);
                    if (!User.IsInRole(SD.SuperAdminEndUser))
                    {
                        consulta = consulta.Where(m => m.FunOrgId == currentUser.Funcionario.IdBeneficiario || 
                                                       m.IdUsuario == currentUser.Funcionario.IdBeneficiario);  
                    }
                    
                    break;
                case Constantes.HRTipoArchivados:
                    consulta = consulta.Where(m => (m.HojaRuta.IdEstadoRegistro == Constantes.Archivado ||
                                                   m.IdEstadoRegistro == Constantes.Archivado));
                    if (!User.IsInRole(SD.SuperAdminEndUser))
                    {
                        consulta = consulta.Where(m => m.FunDstId == currentUser.Funcionario.IdBeneficiario);  
                    }
                    break;
                case Constantes.HRTipoEliminados:
                    consulta = consulta.Where(m => (m.HojaRuta.IdEstadoRegistro == Constantes.Anulado ||
                                              m.IdEstadoRegistro == Constantes.Anulado));
                    
                    if (!User.IsInRole(SD.SuperAdminEndUser))
                    {
                        consulta = consulta.Where(m => m.FunDstId == currentUser.Funcionario.IdBeneficiario);  
                    }
                    break;
                default:
                    consulta = consulta.Where(m => m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado && 
                                                   m.IdEstadoRegistro == Constantes.Registrado);
                    
                    if (!User.IsInRole(SD.SuperAdminEndUser))
                    {
                        consulta = consulta.Where(m => m.FunDstId == currentUser.Funcionario.IdBeneficiario );  
                    }
                    type = Constantes.HRTipoRecibidos;
                    break;
            }
            
           

//            ApplicationUser  currentUser = await GetCurrentUser();
//            if (User.IsInRole(SD.SecretariaUser))
//            {
//               //Puede ver las hojas de ruta del area donde trabaja
//                if (currentUser.Funcionario != null && currentUser.Funcionario.Puesto != null && currentUser.Funcionario.Puesto.UnidadEjecutora != null)
//                {
//                    string currentArea = currentUser.Funcionario.Puesto.UnidadEjecutora;
//                    consulta = consulta.Where(m => m.AreaFuncionarioOrigen == currentArea);
//                }
//                else
//                {
//                    //Puede ver los documentos propios
//                    consulta = consulta.Where(m => m.FuncionarioOrigenId == currentUser.Funcionario.IdBeneficiario);
//                    
//                }
//            } else if (User.IsInRole(SD.DefaultUser))
//            {
//                //Puede ver los documentos propios
//                consulta = consulta.Where(m => m.FuncionarioOrigenId == currentUser.Funcionario.IdBeneficiario);
//            }
            
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"FechaRegistro");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}, {"type", type}, {"typeHR", typeHR}};

            ShowFlash(a);
            ViewBag.filter = filter;
            ViewBag.page = page;
            ViewBag.type = type;
            ViewBag.typeHR = typeHR;
            return View(resp);
        }

        [Breadcrumb("Seguimiento", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Tracking(string filter, string type, string typeHR, DateTime startDate, 
            DateTime endDate, int page = 1, string sortExpression = "-FechaRegistro", string a = "")
        {
            var consulta = DB.CorrespondenciaHojaRuta.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.UnidadEjecutora)
                .Include(m => m.Origen)
                .Where(m => (m.Id > 0));

            if (startDate.Year != 1)
            {
                // DateTime today = DateTime.Now;
                // startDate = new DateTime(today.Year, today.Month, 1);
                // endDate = today.AddDays(1);
                consulta = consulta.Where(m => m.FechaRegistro >= startDate && m.FechaRegistro <= endDate);
            }
            
            if (typeHR != null)
            {
                consulta = consulta.Where(m => m.TipoHojaRuta == typeHR);
            }
            
            if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.Referencia, $"%{filter}%") ||
                                               EF.Functions.ILike(m.RemitenteExterno, $"%{filter}%") ||
                                               EF.Functions.ILike(m.EntidadExterna, $"%{filter}%") ||
                                               EF.Functions.ILike(m.Origen.Denominacion, $"%{filter}%") ||
                                               EF.Functions.ILike(m.UnidadEjecutora.Descripcion, $"%{filter}%") ||
                                               EF.Functions.ILike(m.CiteTramite, $"%{filter}%") ||
                                               EF.Functions.ILike(m.CiteHojaRuta, $"%{filter}%") ||
                                               EF.Functions.ILike(m.CiteUE, $"%{filter}%"));
            }

            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"FechaRegistro");
            resp.Action = "Tracking";

            if (startDate.Year != 1)
            {
                resp.RouteValue = new RouteValueDictionary {{ "filter", filter}, {"startDate", startDate}, {"endDate", endDate}, {"typeHR", typeHR}};
                ViewBag.startDate = startDate.ToString("dd/MM/yyyy");
                ViewBag.endDate = endDate.ToString("dd/MM/yyyy");
            }
            else
            {
                resp.RouteValue = new RouteValueDictionary {{ "filter", filter}, {"typeHR", typeHR}};
                ViewBag.startDate = null;
                ViewBag.endDate = null;
            }
            
            ViewBag.typeHR = typeHR;
            return View(resp);
        }

        // GET: Correspondencia/Documentos/Details/5
        [Breadcrumb("Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Details(Int32? id, bool modal = false, int hrId = 0)
        {
            if (id == null && !modal)
            {
                return View("_NoEncontrado");
            }

            var instrucciones = DB.CorrespondenciaInstrucciones
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Nombre).ToList();
            
           
            HojaRutaDetalle item;
            if (hrId > 0)
            {
                item = await DB.CorrespondenciaHRDetalle
                    .Include(m => m.AreaOrigen)
                    .Include(m => m.AreaDestino)
                    .Include(m => m.FunOrg)
                    .Include(m => m.FunDst)
                    .Include(m => m.HojaRuta)
                    .Include(m => m.HRDetalleInstrucciones)
                    .Include(m => m.HojaRuta.Anexos).ThenInclude(t => t.Tipo)
                    .FirstOrDefaultAsync(m => m.HojaRutaId == hrId);  
            }
            else
            {
                item = await DB.CorrespondenciaHRDetalle
                    .Include(m => m.AreaOrigen)
                    .Include(m => m.AreaDestino)
                    .Include(m => m.FunOrg)
                    .Include(m => m.FunDst)
                    .Include(m => m.HojaRuta)
                    .Include(m => m.HRDetalleInstrucciones)
                    .Include(m => m.HojaRuta.Anexos).ThenInclude(t => t.Tipo)
                    .FirstOrDefaultAsync(m => m.Id == id);    
            }
            
            if (item == null)
            {
                if (modal) return PartialView("_NoEncontrado");
                return View("_NoEncontrado");
            }

            ApplicationUser currentUser = await GetCurrentUser();
            if (!item.Leido && currentUser.Funcionario.IdBeneficiario == item.FunDstId)
            {
                item.Leido = true;
                if (item.FechaRecepcion == null)
                {
                    item.FechaRecepcion = DateTime.Now;
                }

                DB.Update(item);
                await DB.SaveChangesAsync();
            }

           
            ViewBag.isDstUser = false;  
            if (currentUser.Funcionario.IdBeneficiario == item.FunDstId)
            {
                ViewBag.isDstUser = true;    
            }
            
            ViewBag.instrucciones = instrucciones;
            ViewBag.Tipos = DB.CorrespondenciaTipoDocumento.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            ViewBag.documentosId = DB.CorrespondenciaHRDetalle
                .Include(d => d.Documento)
                .Include(d => d.Documento.Tipo)
                .Where(d => d.HojaRutaId == item.HojaRutaId)
                .OrderBy(d => d.FechaRegistro)
                .Select(d => new Documento {Id = d.DocumentoId, Cite = d.Documento.Cite, Tipo = d.Documento.Tipo})
                .ToList();

            ViewBag.isModal = modal;
            if (modal) return PartialView("_Details", item);
            
            return View("_Details",item);
        }

        // GET: Correspondencia/Documentos/Create
        [Breadcrumb("Nueva Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Create(int? idDoc)
        {
            var model = new HojaRutaDTO();
            ApplicationUser currentUser = await GetCurrentUser();
            
            model.FechaDoc = DateTime.Now;
            model.NroFojas = 1;
            model.Parent = 0;
            model.DocumentoId = 0;
            model.OrigenId = currentUser.Funcionario.IdBeneficiario;
            model.Remitente = currentUser.Funcionario.Denominacion;
            model.UnidadEjecutoraId = currentUser.Funcionario.Puesto.UnidadEjecutora.IdUnidadEjecutora;
            model.UnidadEjecutoraNombre = currentUser.Funcionario.Puesto.UnidadEjecutora.Descripcion;
            if (idDoc > 0)
            {
             var doc = await DB.CorrespondenciaDocumento
                 .Include(d => d.FuncionarioOrigen)
                 .Include(d => d.FuncionarioOrigen.Puesto.UnidadEjecutora)
                 .FirstOrDefaultAsync(d => d.Id == idDoc);
                if (doc != null)
                {
                    model.DocumentoId = doc.Id;
                    model.OrigenId = doc.FuncionarioOrigenId;
                    model.Remitente = doc.FuncionarioOrigen.Denominacion;
                    model.UnidadEjecutoraId = doc.FuncionarioOrigen.Puesto.UnidadEjecutora.IdUnidadEjecutora;
                    model.UnidadEjecutoraNombre = doc.AreaFuncionarioOrigen;
                    model.Referencia = doc.Referencia;
                    model.CiteDoc = doc.Cite;
                    model.FechaDoc = doc.Fecha;
                }
            }
            
            var areas = await GetAreas(currentUser.Funcionario.IdBeneficiario);
            var instrucciones = GetInstrucciones();

            ViewBag.choose_user = (User.IsInRole(SD.SecretariaUser) || User.IsInRole(SD.SuperAdminEndUser));
            ViewBag.areas = areas;
            ViewBag.instrucciones = instrucciones;
            ViewBag.Tipos = DB.CorrespondenciaTipoDocumento.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            ViewBag.tiposAnexo = DB.CorrespondenciaTipoAnexo.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            return View("_Create", model);
        }

        // POST: Correspondencia/Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HojaRutaDTO item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                string cite = await GetCite(item.UnidadEjecutoraId);
                HojaRuta hojaRuta = item.prepare(currentUser.AspNetUserId, DB);
                hojaRuta.CiteUE = $"{cite}-CORR.".Replace("NN-", "");
                DB.Add(hojaRuta);
                await DB.SaveChangesAsync();
                
                var parent = hojaRuta.Derivaciones.First(d => d.Padre == -1);

                if (parent != null)
                {
                    foreach (var child in hojaRuta.Derivaciones.Where(d=> d.Padre == 0))
                    {
                        child.Padre = parent.Id;
                    }

                    parent.Padre = 0;
                    DB.SaveChanges();

                }

                SetFlashSuccess("La Hoja de Ruta fue creada correctamente");
                return RedirectToAction(nameof(Index), new{type = Constantes.HRTipoDespachados});
            }
            return View("_Create",item);
        }
        

        [Breadcrumb("Derivar Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Derivar(int id, int? idDoc)
        {
            var item = await DB.CorrespondenciaHRDetalle
                .Include(m => m.HojaRuta)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (item == null)
            {
                return View("_NoEncontrado");
            }
            
            ApplicationUser currentUser = await GetCurrentUser();
            if (item.FunDstId != currentUser.Funcionario.IdBeneficiario)
            {
                return View("_NoAutorizado");
            }

            var model = new HojaRutaDTO();
            model.HojaRutaId = item.HojaRutaId;
            model.OrigenId = item.FunDstId;
            model.UnidadEjecutoraId = item.AreaDestinoId;
            model.Parent = item.Id;
            model.DocumentoId = 0;
            if (idDoc > 0 && DocExists((int) idDoc))
            {
                model.DocumentoId = (int)idDoc;
            }
            
            var areas = await GetAreas(currentUser.Funcionario.IdBeneficiario);
            var instrucciones = GetInstrucciones();
            ViewBag.areas = areas;
            ViewBag.instrucciones = instrucciones;
            ViewBag.HojaRuta = item.HojaRuta;
            ViewBag.Tipos = DB.CorrespondenciaTipoDocumento.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            ViewBag.tiposAnexo = DB.CorrespondenciaTipoAnexo.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            return View("_Derivar", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Derivar(HojaRutaDTO item)
        {
            
            if (item.Instrucciones.Length > 0)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                var hojaRuta = await DB.CorrespondenciaHojaRuta.FirstOrDefaultAsync(m => m.Id == item.HojaRutaId);
                if (hojaRuta == null)
                {
                    return View("_NoEncontrado");
                }
                var detalle = await DB.CorrespondenciaHRDetalle.FirstOrDefaultAsync(m => m.Id == item.Id);
                detalle.IdEstadoRegistro = Constantes.Enviado;
                hojaRuta = item.populateDetalle(hojaRuta, currentUser.AspNetUserId, DB);
                hojaRuta = item.populateAnexos(hojaRuta, currentUser.AspNetUserId, DB);
                DB.Update(hojaRuta);
                DB.Update(detalle);
                await DB.SaveChangesAsync();
                SetFlashSuccess("La Hoja de Ruta fue derivada correctamente");
                return RedirectToAction(nameof(Index));
            }
            return View("_Derivar",item);
        }
        
        public async Task<IActionResult> Flujo(int id, int hrId = 0)
        {

            HojaRutaDetalle item;
            if (hrId > 0)
            {
                item = await DB.CorrespondenciaHRDetalle
                   .Include(m => m.HojaRuta)
                   .OrderBy(a => a.FechaRegistro)
                   .FirstOrDefaultAsync(m => m.HojaRutaId == hrId);
            }
            else
            {
                item = await DB.CorrespondenciaHRDetalle
                    .Include(m => m.HojaRuta)
                    .OrderBy(a => a.FechaRegistro)
                    .FirstOrDefaultAsync(m => m.Id == id);
                
            }

            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }
            
            var derivaciones = DB.CorrespondenciaHRDetalle
                .Include(d => d.HojaRuta)
                .Include(d => d.HRDetalleInstrucciones)
                .Where(d => d.HojaRutaId == item.HojaRutaId)
                .OrderBy(d => d.FechaRegistro)
                .ToList();

            var flow = await FlujoHojaRuta(item.HojaRutaId, item.Id);
            var instrucciones = GetInstrucciones();
            ViewBag.flow = flow;
            ViewBag.instrucciones = instrucciones;
            ViewBag.derivaciones = derivaciones;
            return PartialView("_Flujo", item);
        }
        
        public async Task<IActionResult> CambiarEstado(Int32? id, int nuevoEstado = Constantes.Registrado,
            string from = null)
        {
            if (id == null)
            {
                return View("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaHRDetalle
               .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return View("_NoEncontrado");
            }

            item.IdEstadoRegistro = nuevoEstado;
            DB.Update(item);
            await DB.SaveChangesAsync();
            
            SetFlashSuccess("El estado ha sido cambiado correctamente.");

            if (String.Equals(from, "index"))
            {
                string typeHR = (nuevoEstado == Constantes.Archivado)
                    ? Constantes.HRTipoArchivados
                    : Constantes.HRTipoEliminados;
                
                return RedirectToAction("Index", new {type = typeHR}); 
            }

            return RedirectToAction("Details", new {id = item.Id});  
        }

        // GET: Correspondencia/HojasRutaInterna/HojaRutaPDF
        public async Task<IActionResult> HojaRutaPDF(int id)
        {
            if (id <= 0)
            {
                return View("_NoEncontrado");
            }

            var instrucciones = DB.CorrespondenciaInstrucciones
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Nombre).ToList();
            
            var item = await DB.CorrespondenciaHRDetalle
                .Include(m => m.HojaRuta)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (item == null)
            {
                return View("_NoEncontrado");
            }

            var detalles = DB.CorrespondenciaHRDetalle
                .Include(m => m.AreaOrigen)
                .Include(m => m.AreaDestino)
                .Include(m => m.FunOrg).ThenInclude(f => f.Puesto)
                .Include(m => m.FunDst).ThenInclude(f => f.Puesto)
                .Include(m => m.HojaRuta)
                .Include(m => m.HRDetalleInstrucciones).ThenInclude(d => d.Instruccion)
                .Where(hr => hr.HojaRutaId == item.HojaRutaId && hr.Padre > 0).ToList();
            
            HojaRutaPDFDTO dto = new HojaRutaPDFDTO();
            dto.hojaRuta = item.HojaRuta;
            dto.detalle = item;
            dto.instrucciones = instrucciones;
            dto.derivaciones = detalles;
            // return PartialView("_HojaRuta", dto);
            return new ViewAsPdf("_HojaRuta", dto)
            {
                PageMargins = new Margins(15, 10, 12, 10),
                PageSize = Size.Letter,
                CustomSwitches =  
                    "--footer-left \" © Sistema Integrado Versión 1.0\" --footer-center \" Página: [page]\" --footer-right \"  Documento generado el: " +  
                    DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\"" +  
                    " --footer-line --footer-font-size \"7\" --footer-spacing 1 --footer-font-name \"Segoe UI\""  
           };
        }
        
        public async Task<IActionResult> TrackingPDF(string filter, string type, string typeHR, DateTime startDate, 
                    DateTime endDate, int page = 1, string sortExpression = "-FechaRegistro", string a = "")
                {
                    var consulta = DB.CorrespondenciaHojaRuta.AsNoTracking().AsQueryable();
                    consulta = consulta.Include(m => m.UnidadEjecutora)
                        .Include(m => m.Origen)
                        .Where(m => (m.Id > 0));
        
                    if (startDate.Year == 1)
                    {
                        DateTime today = DateTime.Now;
                        startDate = new DateTime(today.Year, today.Month, 1);
                        endDate = today.AddDays(1);
                    }
        
                    consulta = consulta.Where(m => m.FechaRegistro >= startDate && m.FechaRegistro <= endDate);
                    
                    if (!string.IsNullOrWhiteSpace(filter))
                    {
                        consulta = consulta.Where(m => EF.Functions.ILike(m.Referencia, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.RemitenteExterno, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.EntidadExterna, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.Origen.Denominacion, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.UnidadEjecutora.Descripcion, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.CiteTramite, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.CiteHojaRuta, $"%{filter}%") ||
                                                       EF.Functions.ILike(m.CiteUE, $"%{filter}%"));
                    }
        
                    var resp = await PagingList.CreateAsync(consulta, 10000, page, sortExpression,"FechaRegistro");
                    resp.RouteValue = new RouteValueDictionary {{ "filter", filter}, {"startDate", startDate}, {"endDate", endDate}};
                    
                    return new ViewAsPdf("_TrackingPDF", resp)
                    {
                        PageMargins = new Margins(15, 10, 12, 10),
                        PageSize = Size.Legal,
                        PageOrientation = Orientation.Landscape,
                        CustomSwitches =  
                            "--footer-left \" © Sistema Integrado Versión 1.0\" --footer-center \" Página: [page]\" --footer-right \"  Documento generado el: " +  
                            DateTime.Now.ToString("dd/MM/yyyy HH:mm") + "\"" +  
                            " --footer-line --footer-font-size \"7\" --footer-spacing 1 --footer-font-name \"Segoe UI\""  
                    };
                }

        public async Task<JsonResult> GetDocuments(string filter = "")
        {
            if (filter.Length > 2)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                
                var consulta = DB.CorrespondenciaDocumento
                    .Include(d => d.FuncionarioOrigen)
                    .Include(d => d.FuncionarioOrigen.Puesto.UnidadEjecutora)
                    .Include(d => d.Tipo)
                    .Where(d => (d.IdEstadoRegistro != Constantes.Anulado))
                    .Where(d => EF.Functions.ILike(d.Cite, "%" + filter + "%") || EF.Functions.ILike(d.Referencia, "%" + filter + "%"));
                    
                if (!(User.IsInRole(SD.SecretariaUser) || User.IsInRole(SD.SuperAdminEndUser)))
                {
                    consulta = consulta.Where(d => (d.IdUsuario == currentUser.Funcionario.IdBeneficiario));
                }
                    
                   var documentos = consulta.OrderBy(d => d.Fecha).Take(20)
                    .Select(d => new {Id=d.Id, cite = d.Cite, remitenteId = d.FuncionarioOrigen.IdBeneficiario,
                                      remitente = d.FuncionarioOrigen.Denominacion, cargo = d.CargoFuncionarioOrigen,
                                      area = d.AreaFuncionarioOrigen, areaId = d.FuncionarioOrigen.Puesto.UnidadEjecutora.IdUnidadEjecutora, 
                                      referencia = d.Referencia, fecha = d.Fecha.ToString("yyyy-MM-dd"), fechastr = d.Fecha.ToString("dddd, dd 'de' MMMM  'de' yyyy", new CultureInfo("es-ES")), 
                                      tipo = d.Tipo.Nombre})
                    .ToList();

                

                return Json(new {repositories = documentos});
            }
            else
            {
                return Json(new {repositories = new {}});
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadFiles(IFormFile file)
        {
            long size = file.Length;

            // full path to file in temp location
//            var filePath = Path.GetTempFileName();
            var uploadPath = Path.Combine("uploads", "correspondencia", DateTime.Today.ToString("yyyy-MM-dd"));
            var filePath = Path.Combine(hostingEnvironment.WebRootPath, uploadPath);
            var newName = $"{DateTime.Now.Ticks}_{file.FileName.RemoveDiacritics().Replace(" ", "_")}";
            var fullPath = Path.Combine(filePath, newName);
            
            var fileToUpload = Path.Combine(uploadPath, newName);
            
            if (file.Length > 0)
            {
                if (!Directory.Exists(filePath)) 
                {
                    DirectoryInfo di = Directory.CreateDirectory(filePath);
                }
 
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.

            return Ok(new { file.FileName, size, fileToUpload});
        }

        private bool DocExists(Int32 id)
        {
            return DB.CorrespondenciaDocumento.Any(e => e.Id == id);
        }
    }
}
