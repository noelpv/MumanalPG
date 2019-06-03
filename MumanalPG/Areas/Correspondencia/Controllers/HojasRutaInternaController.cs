using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class HojasRutaInternaController : BaseController
    {        
        
		public HojasRutaInternaController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/Documentos
        [Breadcrumb("Correspondencia Interna", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, string type, int page = 1, string sortExpression = "-Id", string a = "")
        {

            var consulta = DB.CorrespondenciaHRDetalle.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.AreaOrigen)
                               .Include(m => m.AreaDestino)
                               .Include(m => m.FunOrg)
                               .Include(m => m.FunDst)
                               .Include(m => m.HojaRuta)
                               .Where(m => (m.HojaRuta.TipoHojaRuta == Constantes.HojaRutaInterna)); 
            
            
            ApplicationUser currentUser = await GetCurrentUser();
            switch (type)
            {
                case Constantes.HRTipoUrgentes:
                    consulta = consulta.Where(m => m.HojaRuta.Prioridad == Constantes.PrioridadUrgente &&
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado && 
                                                   m.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.IdEstadoRegistro != Constantes.Archivado);
                    break;
                case Constantes.HRTipoDespachados:
                    consulta = consulta.Where(m => m.FunOrgId == currentUser.Funcionario.IdBeneficiario &&
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado && 
                                                   m.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.IdEstadoRegistro != Constantes.Archivado);
                    break;
                case Constantes.HRTipoArchivados:
                    consulta = consulta.Where(m => m.HojaRuta.IdEstadoRegistro == Constantes.Archivado ||
                                                   m.IdEstadoRegistro == Constantes.Archivado);
                    break;
                case Constantes.HRTipoEliminados:
                    consulta = consulta.Where(m => m.HojaRuta.IdEstadoRegistro == Constantes.Anulado ||
                                              m.IdEstadoRegistro == Constantes.Anulado);
                    break;
                default:
                    consulta = consulta.Where(m => m.FunDstId == currentUser.Funcionario.IdBeneficiario &&
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.HojaRuta.IdEstadoRegistro != Constantes.Archivado && 
                                                   m.IdEstadoRegistro != Constantes.Anulado && 
                                                   m.IdEstadoRegistro != Constantes.Archivado);
                    type = Constantes.HRTipoRecibidos;
                    break;
            }
            
            if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.HojaRuta.Referencia, $"%{filter}%"));
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
            
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"-Id");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};

            ShowFlash(a);
            ViewBag.page = page;
            ViewBag.type = type;
            return View(resp);
        }

        // GET: Correspondencia/Documentos/Details/5
        [Breadcrumb("Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return View("_NoEncontrado");
            }

            var instrucciones = DB.CorrespondenciaInstrucciones
                .Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Nombre).ToList();
            
            var item = await DB.CorrespondenciaHRDetalle
                                .Include(m => m.AreaOrigen)
                                .Include(m => m.AreaDestino)
                                .Include(m => m.FunOrg)
                                .Include(m => m.FunDst)
                                .Include(m => m.HojaRuta)
                                .Include(m => m.HRDetalleInstrucciones)
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return View("_NoEncontrado");
            }

            if (!item.Leido)
            {
                item.Leido = true;
                if (item.FechaRecepcion == null)
                {
                    item.FechaRecepcion = DateTime.Now;
                }

                DB.Update(item);
                await DB.SaveChangesAsync();
            }

            ViewBag.instrucciones = instrucciones;
            return View("_Details",item);
        }

        // GET: Correspondencia/Documentos/Create
        [Breadcrumb("Nueva Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Create()
        {
            var model = new HojaRutaDTO();
            model.FechaDoc = DateTime.Now;
            model.NroFojas = 1;

            ApplicationUser currentUser = await GetCurrentUser();
            var areas = await GetAreas(currentUser.Funcionario.IdBeneficiario);
            var instrucciones = GetInstrucciones();
            ViewBag.areas = areas;
            ViewBag.instrucciones = instrucciones;
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
                HojaRuta hojaRuta = item.prepare(currentUser.AspNetUserId, DB);
                DB.Add(hojaRuta);
                await DB.SaveChangesAsync();
                SetFlashSuccess("La Hoja de Ruta fue creada correctamente");
                return RedirectToAction(nameof(Index));
            }
            return View("_Create",item);
        }

        // GET: Correspondencia/Documentos/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }
            
            var item = await DB.CorrespondenciaDocumento
                .Include(m => m.Tipo)
                .Include(m => m.FuncionarioOrigen)
                .Include(m => m.FuncionarioDestino)
                .Include(m => m.FuncionarioVia)
                .Include(m => m.FuncionarioCC)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }
            
            ApplicationUser  currentUser = await GetCurrentUser();
            if(User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.SuperAdminEndUser) ||
               currentUser.AspNetUserId == item.IdUsuario || currentUser.Funcionario.IdBeneficiario == item.FuncionarioOrigenId)
            {
                
                item.NombreOrigen = item.FuncionarioOrigen.Denominacion;
                item.NombreDestino = item.FuncionarioDestino.Denominacion;

                if (item.FuncionarioViaId > 0)
                {
                    item.NombreVia = item.FuncionarioVia.Denominacion;
                }
            
                if (item.FuncionarioCCId > 0)
                {
                    item.NombreCC = item.FuncionarioCC.Denominacion;
                }

                return PartialView( "_Edit", item);

            }

            return PartialView("_NoAutorizado");
        }

        // POST: Correspondencia/Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Correspondencia.Documento item)
        {
            if (id != item.Id)
            {
                return PartialView("_NoEncontrado");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.Id))
                    {
                        return PartialView("_NoEncontrado");
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return PartialView("_Edit", item);
        }

        [Breadcrumb("Derivar Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Derivar(int id)
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
            model.Id = item.HojaRutaId;
            model.OrigenId = item.FunDstId;
            model.UnidadEjecutoraId = item.AreaDestinoId;

            var areas = await GetAreas(currentUser.Funcionario.IdBeneficiario);
            var instrucciones = GetInstrucciones();
            ViewBag.areas = areas;
            ViewBag.instrucciones = instrucciones;
            ViewBag.HojaRuta = item.HojaRuta;
            return View("_Derivar", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Derivar(HojaRutaDTO item)
        {
            
            if (item.Instrucciones.Length > 0)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                var hojaRuta = await DB.CorrespondenciaHojaRuta.FirstOrDefaultAsync(m => m.Id == item.Id);
                item.populateDetalle(hojaRuta, currentUser.AspNetUserId, DB);
                DB.Update(hojaRuta);
                await DB.SaveChangesAsync();
                SetFlashSuccess("La Hoja de Ruta fue derivada correctamente");
                return RedirectToAction(nameof(Index));
            }
            return View("_Derivar",item);
        }
        
        // GET: Correspondencia/Documentos/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaDocumento.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }

            if(!(User.IsInRole(SD.AdminEndUser) || User.IsInRole(SD.SuperAdminEndUser)))
            {
                ApplicationUser  currentUser = await GetCurrentUser();
                if (currentUser.AspNetUserId != item.IdUsuario)
                {
                    return PartialView("_NoAutorizado");
                }

            }
           
            return PartialView("_Delete",item);
        }

        // POST: Correspondencia/Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.CorrespondenciaDocumento.FindAsync(id);
            item.IdEstadoRegistro = Constantes.Anulado;
            DB.CorrespondenciaDocumento.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("_Delete",item);
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

        public JsonResult GetDocuments(string filter = "")
        {
            if (filter.Length > 2)
            {
                var documentos = DB.CorrespondenciaDocumento
                    .Include(d => d.FuncionarioOrigen)
                    .Include(d => d.FuncionarioOrigen.Puesto.UnidadEjecutora)
                    .Include(d => d.Tipo)
                    .Where(d => (d.IdEstadoRegistro != Constantes.Anulado))
                    .Where(d => EF.Functions.ILike(d.Cite, "%" + filter + "%") || EF.Functions.ILike(d.Referencia, "%" + filter + "%"))
                    .OrderBy(d => d.Fecha).Take(20)
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

        private bool ItemExists(Int32 id)
        {
            return DB.CorrespondenciaDocumento.Any(e => e.Id == id);
        }
    }
}
