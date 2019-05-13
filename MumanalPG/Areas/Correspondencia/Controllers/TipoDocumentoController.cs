using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Correspondencia")]
    public class TipoDocumentoController : BaseController
    {        
		public TipoDocumentoController(ApplicationDbContext db): base(db)
        {

        }

		// GET: Correspondencia/TipoDocumento
        [Breadcrumb("Tipos de Documento", FromController = "Dashboard", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Nombre")
        { 
            var consulta = DB.Correspondencia_TipoDocumento.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.Estado != "ELIMINADO");
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Nombre, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"Nombre");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            return View(resp);
        }

        // GET: Correspondencia/TipoDocumento/Details/5
        public async Task<IActionResult> Details(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Correspondencia_TipoDocumento.FirstOrDefaultAsync(m => m.Id == id);
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
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
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

            var item = await DB.Correspondencia_TipoDocumento.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "_Edit", item);
        }

        // POST: Correspondencia/TipoDocumento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int16 id, [Bind("Id,Nombre,Descripcion,Estado")] Models.Correspondencia.TipoDocumento item)
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
                SetFlashSuccess("Registro modificado satisfactoriamente");
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

            var item = await DB.Correspondencia_TipoDocumento.FirstOrDefaultAsync(m => m.Id == id);
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
            var item = await DB.Correspondencia_TipoDocumento.FindAsync(id);
            item.Estado = "ELIMINADO";
            DB.Correspondencia_TipoDocumento.Update(item);
            await DB.SaveChangesAsync();
            SetFlashSuccess("Registro eliminado satisfactoriamente");
            return PartialView("_Delete",item);
        }

        private bool ItemExists(Int16 id)
        {
            return DB.Correspondencia_TipoDocumento.Any(e => e.Id == id);
        }
    }
}
