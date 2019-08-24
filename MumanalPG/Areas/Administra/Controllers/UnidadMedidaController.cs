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

namespace MumanalPG.Areas.Administra.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Administra")]
    public class UnidadMedidaController : BaseController
    {        
        
		public UnidadMedidaController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Administra/UnidadMedida
        [Breadcrumb("UnidadMedida", FromController = "DashboardAdministra", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.UnidadMedida.AsNoTracking().AsQueryable();
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

        // GET: Administra/UnidadMedida/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.UnidadMedida.FirstOrDefaultAsync(m => m.IdUnidadMedida  == id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView("Details",item);
        }

        // GET: Administra/UnidadMedida/Create
        public IActionResult Create()
        {
            var model = new Models.Administra.UnidadMedida();
            //ini combo
            var items = DB.TipoUnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.TipoUnidadMedida = items;
            //Fin combo
            return PartialView("Create", model);
        }

        // POST: Administra/UnidadMedida/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Administra.UnidadMedida item)
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
            var items = DB.TipoUnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.TipoUnidadMedida = items;

            return PartialView("Create",item);
        }

        // GET: Administra/UnidadMedida/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.UnidadMedida.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var items = DB.TipoUnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.TipoUnidadMedida = items;

            return PartialView( "Edit", item);
        }

        // POST: Administra/UnidadMedida/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id,  Models.Administra.UnidadMedida item)
        {
            if (id != item.IdUnidadMedida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    //item.Gestion = Convert.ToString(DateTime.Now.Year);
                    //item.IdBeneficiario = 0;
                    //item.IdPais = 1;
                    //item.CargoRepresentante = "-";
                    item.IdEstadoRegistro = 1;
                    item.FechaRegistro = DateTime.Now;
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdUnidadMedida))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            var items = DB.TipoUnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.TipoUnidadMedida = items;

            return PartialView("Edit", item);
        }

        // GET: Administra/UnidadMedida/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.UnidadMedida.FirstOrDefaultAsync(m => m.IdUnidadMedida == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Administra/UnidadMedida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.UnidadMedida.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.UnidadMedida.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.UnidadMedida.Any(e => e.IdUnidadMedida == id);
        }
    }
}
