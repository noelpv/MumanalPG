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

namespace MumanalPG.Areas.Finanzas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Finanzas")]
    public class TipoMonedaController : BaseController
    {        
        
		public TipoMonedaController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Finanzas/TipoMoneda
        //[Breadcrumb("TipoMoneda", FromController = "DashboardTC", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.TipoMoneda.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Finanzas/TipoMoneda/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.TipoMoneda.FirstOrDefaultAsync(m => m.IdTipoMoneda  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/TipoMoneda/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.TipoMoneda();
            return PartialView("Create", model);
        }

        // POST: Finanzas/TipoMoneda/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.TipoMoneda item)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser currentUser = await GetCurrentUser();
                //item.IdUsuario = currentUser.AspNetUserId;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("Create",item);
        }

        // GET: Finanzas/TipoMoneda/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.TipoMoneda.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "Edit", item);
        }

        // POST: Finanzas/TipoMoneda/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdTipoMoneda,Descripcion,Sigla")] Models.Finanzas.TipoMoneda item)
        {
            if (id != item.IdTipoMoneda)
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
                    if (!ItemExists(item.IdTipoMoneda))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return PartialView("Edit", item);
        }

        // GET: Finanzas/TipoMoneda/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.TipoMoneda.FirstOrDefaultAsync(m => m.IdTipoMoneda == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/TipoMoneda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.TipoMoneda.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.TipoMoneda.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.TipoMoneda.Any(e => e.IdTipoMoneda == id);
        }
    }
}
