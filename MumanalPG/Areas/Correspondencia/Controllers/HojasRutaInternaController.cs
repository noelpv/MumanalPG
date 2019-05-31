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
using MumanalPG.Utility;
using Newtonsoft.Json;
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
        [Breadcrumb("Interna", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "-Id", string a = "")
        {

            var consulta = DB.CorrespondenciaHojaRuta.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.Origen)
                               .Include(m => m.UnidadEjecutora)
                               .Where(m => (m.IdEstadoRegistro != Constantes.Anulado && 
                                            m.TipoHojaRuta == Constantes.HojaRutaInterna)); 
            
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Referencia, $"%{filter}%"));
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
            //resp.Action = $"Index?type={type}";
            return View(resp);
        }

        // GET: Correspondencia/Documentos/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaHojaRuta
                                .FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/Documentos/Create
        [Breadcrumb("Nueva Hoja de Ruta", FromAction = "Index")]
        public async Task<IActionResult> Create()
        {
            var model = new Models.Correspondencia.DTO.HojaRutaDTO();
            model.FechaDoc = DateTime.Now;
            model.NroFojas = 1;

            var areas = await GetAreas();
            var instrucciones = GetInstrucciones();
            ViewBag.areas = areas;
            ViewBag.instrucciones = instrucciones;
            return View("_Create", model);
        }

        // POST: Correspondencia/Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Correspondencia.DTO.HojaRutaDTO item)
        {
            
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                HojaRuta hojaRuta = item.prepare(currentUser.AspNetUserId);
                System.Console.WriteLine("======================================");
                System.Console.WriteLine(JsonConvert.SerializeObject(item));
               
//                foreach (var ins in item.GetInstrucciones())
//                {
//                    System.Console.WriteLine(ins.id);
//                    System.Console.WriteLine(ins.funDstId);
//                    System.Console.WriteLine(String.Join(", ", ins.instrucciones));
//                    System.Console.WriteLine(String.Join(", ", ins.comentarios));
//                }
                
                System.Console.WriteLine("======================================");
              
                //ApplicationUser currentUser = await GetCurrentUser();
//                string cite = await GetCite(item.AreaFuncionarioOrigenId);
//                item.IdUsuario =  currentUser.AspNetUserId;
//                item.Cite = cite;
//                item.FechaRegistro = DateTime.Now;
//                item.IdEstadoRegistro = Constantes.Registrado;
                DB.Add(hojaRuta);
                await DB.SaveChangesAsync();
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
