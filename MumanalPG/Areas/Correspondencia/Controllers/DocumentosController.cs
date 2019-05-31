using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class DocumentosController : BaseController
    {        
        
		public DocumentosController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/Documentos
        [Breadcrumb("Documentos", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, Int16 type, int page = 1, string sortExpression = "-Id", string a = "")
        {

            if (type == 0)
            {
                type = 1;
            }
            //Admin y Ventanilla pueden ver todos los documentos
            var consulta = DB.CorrespondenciaDocumento.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.FuncionarioOrigen)
                               .Include(m => m.FuncionarioDestino)
                               .Include(m => m.Tipo)
                               .Where(m => (m.IdEstadoRegistro != Constantes.Anulado && m.TipoId == type)); // el estado es diferente a ANULADO
            
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Referencia, $"%{filter}%"));
            }

            ApplicationUser  currentUser = await GetCurrentUser();
            if (User.IsInRole(SD.SecretariaUser))
            {
               //Puede ver los documentos del area donde trabaja
                if (currentUser.Funcionario != null && currentUser.Funcionario.Puesto != null && currentUser.Funcionario.Puesto.UnidadEjecutora != null)
                {
                    string currentArea = currentUser.Funcionario.Puesto.UnidadEjecutora.Descripcion;
                    consulta = consulta.Where(m => m.AreaFuncionarioOrigen == currentArea);
                }
                else
                {
                    //Puede ver los documentos propios
                    consulta = consulta.Where(m => m.FuncionarioOrigenId == currentUser.Funcionario.IdBeneficiario);
                    
                }
            } else if (User.IsInRole(SD.DefaultUser))
            {
                //Puede ver los documentos propios
                consulta = consulta.Where(m => m.FuncionarioOrigenId == currentUser.Funcionario.IdBeneficiario);
            }

            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"-Id");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}, {"type", type}};

            ShowFlash(a);
            ViewBag.Tipos = DB.CorrespondenciaTipoDocumento.Where(t => t.IdEstadoRegistro != Constantes.Anulado).ToList();
            ViewBag.docTipoId = type;
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

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/Documentos/Create
        public async Task<IActionResult> Create(Int16 type)
        {
            ApplicationUser  currentUser = await GetCurrentUser();
            var model = new Models.Correspondencia.Documento();
            model.TipoId = type;
            model.FuncionarioCCId = -1;
            model.FuncionarioViaId = -1;
            model.Fecha = DateTime.Now;
            model.FuncionarioOrigenId = currentUser.Funcionario.IdBeneficiario;
            model.NombreOrigen = currentUser.Funcionario.Denominacion;
            model.CargoFuncionarioOrigen = currentUser.Funcionario.Puesto.Descripcion;
            model.AreaFuncionarioOrigenId = currentUser.Funcionario.Puesto.UnidadEjecutora.IdUnidadEjecutora;
            model.AreaFuncionarioOrigen = currentUser.Funcionario.Puesto.UnidadEjecutora.Descripcion;
            return PartialView("_Create", model);
        }

        // POST: Correspondencia/Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Correspondencia.Documento item)
        {
            
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                string cite = await GetCite(item.AreaFuncionarioOrigenId);
                item.IdUsuario =  currentUser.AspNetUserId;
                item.Cite = cite;
                item.FechaRegistro = DateTime.Now;
                item.IdEstadoRegistro = Constantes.Registrado;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("_Create",item);
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

        

        private bool ItemExists(Int32 id)
        {
            return DB.CorrespondenciaDocumento.Any(e => e.Id == id);
        }
    }
}
