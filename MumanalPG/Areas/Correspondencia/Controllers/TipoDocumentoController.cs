using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    [Authorize(Roles = SD.AdminAccess)]
    [Area("Correspondencia")]
    public class TipoDocumentoController : BaseController
    {        
        
		public TipoDocumentoController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/TipoDocumento
        [Breadcrumb("Tipos de Documento", FromController = "Dashboard", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre", string a = "")
        { 
            var consulta = DB.CorrespondenciaTipoDocumento.AsNoTracking().AsQueryable();
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

        // GET: Correspondencia/TipoDocumento/Details/5
        public async Task<IActionResult> Details(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaTipoDocumento.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/TipoDocumento/Create
        public IActionResult Create()
        {
            var model = new Models.Correspondencia.TipoDocumento();
            return PartialView("_Create", model);
        }

        // POST: Correspondencia/TipoDocumento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Correspondencia.TipoDocumento item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario =  currentUser.AspNetUserId;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("_Create",item);
        }

        // GET: Correspondencia/TipoDocumento/Edit/5
        public async Task<IActionResult> Edit(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaTipoDocumento.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "_Edit", item);
        }

        // POST: Correspondencia/TipoDocumento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int16 id, [Bind("Id,Nombre,Descripcion")] Models.Correspondencia.TipoDocumento item)
        {
            if (id != item.Id)
            {
                return NotFound();
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
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return PartialView("_Edit", item);
        }

        // GET: Correspondencia/TipoDocumento/Delete/5
        public async Task<IActionResult> Delete(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaTipoDocumento.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Delete",item);
        }

        // POST: Correspondencia/TipoDocumento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int16 id)
        {
            var item = await DB.CorrespondenciaTipoDocumento.FindAsync(id);
            item.IdEstadoRegistro = Constantes.Anulado;
            DB.CorrespondenciaTipoDocumento.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("_Delete",item);
        }

        private bool ItemExists(Int16 id)
        {
            return DB.CorrespondenciaTipoDocumento.Any(e => e.Id == id);
        }
    }
}
