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
    public class PlanCuentasController : BaseController
    {        
        
		public PlanCuentasController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Finanzas/PlanCuentas
        //[Breadcrumb("PlanCuentas", FromController = "DashboardPlan", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "NombreCuenta", string a = "")
        { 
            var consulta = DB.PlanCuentas.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.NombreCuenta, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "NombreCuenta");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Finanzas/PlanCuentas/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.PlanCuentas.FirstOrDefaultAsync(m => m.IdPlanCuentas  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/PlanCuentas/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.PlanCuentas();
            /* Consultar si introducir combo repetido */
            var items = new List<SelectListItem>();
            items = DB.Auxiliar.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdAuxiliar.ToString()
                   }).
                   ToList();
            ViewBag.Auxiliar = items;

            return PartialView("Create", model);
        }

        // POST: Finanzas/PlanCuentas/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.PlanCuentas item, string Auxiliar)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = '1';
                item.FechaRegistro = DateTime.Now;
                item.IdAuxiliar1 = Convert.ToInt32(Auxiliar);
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            return PartialView("Create",item);
        }

        // GET: Finanzas/PlanCuentas/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.PlanCuentas.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DB.Auxiliar.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdAuxiliar.ToString()
                   }).
                   ToList();
            ViewBag.Auxiliar = items;

            return PartialView( "Edit", item);
        }

        // POST: Finanzas/PlanCuentas/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdPlanCuentas,NombreCuenta,Sigla, IdAuxiliar1")] Models.Finanzas.PlanCuentas item, string Auxiliar)
        {
            if (id != item.IdPlanCuentas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.IdAuxiliar1 = Convert.ToInt32(Auxiliar);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdPlanCuentas))
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

        // GET: Finanzas/PlanCuentas/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.PlanCuentas.FirstOrDefaultAsync(m => m.IdPlanCuentas == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/PlanCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.PlanCuentas.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.PlanCuentas.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.PlanCuentas.Any(e => e.IdPlanCuentas == id);
        }
    }
}
