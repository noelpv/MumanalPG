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
    public class InstruccionesController : BaseController
    {        
        
		public InstruccionesController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/Instrucciones
        [Breadcrumb("Instrucciones", FromController = "Dashboard", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre", string a = "")
        { 
            var consulta = DB.CorrespondenciaInstrucciones.AsNoTracking().AsQueryable();
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
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaInstrucciones.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/Instrucciones/Create
        public IActionResult Create()
        {
            var model = new Models.Correspondencia.Instrucciones();
            return PartialView("_Create", model);
        }

        // POST: Correspondencia/Instrucciones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Correspondencia.Instrucciones item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario =  currentUser.AspNetUserId;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            return PartialView("_Create",item);
        }

        // GET: Correspondencia/Instrucciones/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaInstrucciones.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "_Edit", item);
        }

        // POST: Correspondencia/Instrucciones/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("Id,Nombre,Descripcion")] Models.Correspondencia.Instrucciones item)
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

        // GET: Correspondencia/Instrucciones/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaInstrucciones.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Delete",item);
        }

        // POST: Correspondencia/Instrucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.CorrespondenciaInstrucciones.FindAsync(id);
            item.IdEstadoRegistro = Constantes.Anulado;
            DB.CorrespondenciaInstrucciones.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("_Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.CorrespondenciaInstrucciones.Any(e => e.Id == id);
        }
    }
}
