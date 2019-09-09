using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Dynamic;
using Microsoft.AspNetCore.Http;
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
using MumanalPG.Extensions;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;

namespace MumanalPG.Areas.Generales.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Generales")]
    public class BarrioController : BaseController
    {        
        
		public BarrioController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Generales/Barrio
        [Breadcrumb("Barrio", FromController = "DashboardGenerales", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.Barrio.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.ZonaDB).Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Generales/Barrio/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Barrio.Include(m => m.ZonaDB).FirstOrDefaultAsync(m => m.IdBarrio  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Generales/Barrio/Create
        public IActionResult Create()
        {
            var model = new Models.Generales.Barrio();
            ViewBag.Zona = DB.Zona.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Create", model);
        }

        // POST: Generales/Barrio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Generales.Barrio item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            ViewBag.Zona = DB.Zona.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Create",item);
        }

        // GET: Generales/Barrio/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Barrio.Include(m => m.ZonaDB).FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.Zona = DB.Zona.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();

            return PartialView( "Edit", item);
        }

        // POST: Generales/Barrio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Generales.Barrio item)
        {
            if (id != item.IdBarrio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    item.IdEstadoRegistro = 1;
                    item.FechaRegistro = DateTime.Now;
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdBarrio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            ViewBag.Zona = DB.Zona.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Edit", item);
        }

        // GET: Generales/Barrio/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Barrio.FirstOrDefaultAsync(m => m.IdBarrio == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Generales/Barrio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Barrio.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Barrio.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Barrio.Any(e => e.IdBarrio == id);
        }
    }
}
