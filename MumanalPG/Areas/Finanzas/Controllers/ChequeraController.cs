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

namespace MumanalPG.Areas.Finanzas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Finanzas")]
    public class ChequeraController : BaseController
    {        
        
		public ChequeraController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Finanzas/Chequera
        [Breadcrumb("Dosificación de Chequeras", FromController = "DashboardFinanzas", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "IdDocumentoRespaldo", string a = "")
        { 
            var consulta = DB.Chequera.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.DocumentoRespaldoDB)
                               .Include(m => m.BeneficiarioDB)
                               .Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.DocumentoRespaldoDB.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "IdDocumentoRespaldo");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Finanzas/Chequera/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Chequera.Include(m => m.DocumentoRespaldoDB)
                                    .Include(m => m.BeneficiarioDB)
                                    .FirstOrDefaultAsync(m => m.IdChequera  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/Chequera/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.Chequera();

            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;

            return PartialView("Create", model);
        }

        // POST: Finanzas/Chequera/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.Chequera item)
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

        // GET: Finanzas/Chequera/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Chequera.Include(m => m.BeneficiarioDB)
                .FirstOrDefaultAsync(m => m.IdChequera == id);
            if (item == null)
            {
                return NotFound();
            }

            item.NombreBeneficiario = item.BeneficiarioDB.Denominacion;
            
            var items1 = DB.Ventas_DocumentoRespaldo.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoRespaldo = items1;

            return PartialView("Edit", item);
        }

        // POST: Finanzas/Chequera/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Finanzas.Chequera item)
        {
            if (id != item.IdChequera)
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
                    if (!ItemExists(item.IdChequera))
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

        // GET: Finanzas/Chequera/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Chequera.FirstOrDefaultAsync(m => m.IdChequera == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/Chequera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Chequera.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Chequera.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Chequera.Any(e => e.IdChequera == id);
        }

        public JsonResult ListaBeneficiarios(string filter = "")
        {
            if (filter.Length > 2)
            {
                var listaBenef = DB.RRHH_Beneficiario
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado || b.IdEstadoRegistro == null))
                    .Where(b => EF.Functions.ILike(b.Denominacion, "%" + filter + "%") || EF.Functions.ILike(b.DocumentoIdentidad, "%" + filter + "%"))
                    .OrderBy(d => d.PrimerApellido).Take(20)
                    .Select(c => new {Id=c.IdBeneficiario, Nombre = c.Denominacion, Carnet = c.DocumentoIdentidad})
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
