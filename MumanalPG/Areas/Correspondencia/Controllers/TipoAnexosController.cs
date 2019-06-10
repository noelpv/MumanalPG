using System;
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
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Correspondencia")]
    public class TipoAnexosController : BaseController
    {        
        
		public TipoAnexosController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/Instrucciones
        [Breadcrumb("Tipo Anexos", FromController = "Dashboard", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre", string a = "")
        { 
            var consulta = DB.CorrespondenciaTipoAnexo.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != Constantes.Anulado); // el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Nombre, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"Nombre");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Correspondencia/Instrucciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaTipoAnexo.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/Instrucciones/Create
        public IActionResult Create()
        {
            var model = new Models.Correspondencia.TipoAnexo();
            return PartialView("_Create", model);
        }

        // POST: Correspondencia/Instrucciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoAnexo item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario =  currentUser.AspNetUserId;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("_Create",item);
        }

        // GET: Correspondencia/Instrucciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaTipoAnexo.FindAsync(id);
            if (item == null)
            {
                return PartialView("_NoEncontrado");
            }
            return PartialView( "_Edit", item);
        }

        // POST: Correspondencia/Instrucciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  TipoAnexo item)
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

        // GET: Correspondencia/Instrucciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return PartialView("_NoEncontrado");
            }

            var item = await DB.CorrespondenciaTipoAnexo.FirstOrDefaultAsync(m => m.Id == id);
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

        // POST: Correspondencia/Instrucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.CorrespondenciaTipoAnexo.FindAsync(id);
            item.IdEstadoRegistro = Constantes.Anulado;
            DB.CorrespondenciaTipoAnexo.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("_Delete",item);
        }

        private bool ItemExists(int id)
        {
            return DB.CorrespondenciaTipoAnexo.Any(e => e.Id == id);
        }
    }
}
