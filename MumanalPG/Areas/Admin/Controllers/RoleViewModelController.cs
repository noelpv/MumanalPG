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
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Admin.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Admin")]
    public class RoleViewModelController : BaseController
    {
        
		public RoleViewModelController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Admin/RoleViewModel
        // [Breadcrumb("Tipos de Transaccion", FromController = "DashboardFinanzas", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Name", string a = "")
        { 
            var consulta = DB.Roles.AsNoTracking().AsQueryable();
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Name, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Name");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Admin/RoleViewModel/Details/5
        public async Task<IActionResult> Details(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Admin/RoleViewModel/Create
        public IActionResult Create()
        {
            var model = new IdentityRole();
            return PartialView("Create", model);
        }

        // POST: Admin/RoleViewModel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole item)
        {
            if (ModelState.IsValid)
            {
                //ApplicationUser currentUser = await GetCurrentUser();
                //item.IdUsuario = currentUser.AspNetUserId;
                //item.IdEstadoRegistro = 1;
                //item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("Create",item);
        }

        // GET: Admin/RoleViewModel/Edit/5
        public async Task<IActionResult> Edit(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Roles.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "Edit", item);
        }

        // POST: Admin/RoleViewModel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(String id, IdentityRole item)
        {
            if (id != item.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //ApplicationUser currentUser = await GetCurrentUser();
                    //item.IdUsuario = currentUser.AspNetUserId;
                    //item.IdEstadoRegistro = 1;
                    //item.FechaRegistro = DateTime.Now;
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
            return PartialView("Edit", item);
        }

        // GET: Admin/RoleViewModel/Delete/5
        public async Task<IActionResult> Delete(String id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Roles.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Admin/RoleViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(String id)
        {
            var item = await DB.Roles.FindAsync(id);
            DB.Roles.Remove(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(String id)
        {
            return DB.Roles.Any(e => e.Id == id);
        }
    }
}
