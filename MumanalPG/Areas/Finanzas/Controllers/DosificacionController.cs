using System;
using System.Collections.Generic;
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
    public class DosificacionController : BaseController
    {        
        
		public DosificacionController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Finanzas/Dosificacion
        [Breadcrumb("Dosificacion", FromController = "DashboardFinanzas", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "NumeroAutorizacion", string a = "")
        { 
            var consulta = DB.Dosificacion.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.NumeroAutorizacion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "NumeroAutorizacion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Finanzas/Dosificacion/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Dosificacion.FirstOrDefaultAsync(m => m.IdDosificacion  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/Dosificacion/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.Dosificacion();

            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;

            return PartialView("Create", model);
        }

        // POST: Finanzas/Dosificacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.Dosificacion item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                item.IdBeneficiarioResponsable = 0;
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;
            return PartialView("Create",item);
        }

        // GET: Finanzas/Dosificacion/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Dosificacion.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;

            return PartialView("Edit", item);
        }

        // POST: Finanzas/Dosificacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Finanzas.Dosificacion item)
        {
            if (id != item.IdDosificacion)
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
                    item.IdBeneficiarioResponsable = 0;
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdDosificacion))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;
            return PartialView("Edit", item);
        }

        // GET: Finanzas/Dosificacion/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Dosificacion.FirstOrDefaultAsync(m => m.IdDosificacion == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/Dosificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Dosificacion.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Dosificacion.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Dosificacion.Any(e => e.IdDosificacion == id);
        }

        public JsonResult ListaBeneficiarios(string filter = "")
        {
            if (filter.Length > 2)
            {
                var listaBenef = DB.RRHH_Beneficiario
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado || b.IdEstadoRegistro == null))
                    .Where(b => EF.Functions.ILike(b.PrimerNombre, "%" + filter + "%") || EF.Functions.ILike(b.PrimerApellido, "%" + filter + "%") || EF.Functions.ILike(b.DocumentoIdentidad, "%" + filter + "%"))
                    .OrderBy(d => d.PrimerApellido).Take(20)
                    .Select(c => new {Id=c.IdBeneficiario, Nombre = c.PrimerNombre, Apellido = c.PrimerApellido, Carnet = c.DocumentoIdentidad})
                    .ToList(); 
                
                return Json(new {repositories = listaBenef});
            }
            else
            {
                return Json(new {repositories = new {}});
            }
        }
    }
}
