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

namespace MumanalPG.Areas.Planificacion.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Planificacion")]
    public class OrganismoFinanciadorController : BaseController
    {        
        
		public OrganismoFinanciadorController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Planificacion/OrganismoFinanciador
        [Breadcrumb("OrganismoFinanciador", FromController = "DashboardPlan", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.OrganismoFinanciador.AsNoTracking().AsQueryable();
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

        // GET: Planificacion/OrganismoFinanciador/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.OrganismoFinanciador.FirstOrDefaultAsync(m => m.IdOrganismoFinanciador  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Planificacion/OrganismoFinanciador/Create
        public IActionResult Create()
        {
            var model = new Models.Planificacion.OrganismoFinanciador();

            var items = new List<SelectListItem>();
            items = DB.FuenteFinanciamiento.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdFuenteFinanciamiento.ToString()
                   }).
                   ToList();
            ViewBag.FuenteFinanciamiento = items;

            return PartialView("Create", model);
        }

        // POST: Planificacion/OrganismoFinanciador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Planificacion.OrganismoFinanciador item, string FuenteFinanciamiento)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.Gestion = "2019";
                item.IdBeneficiario = '0';
                item.IdPais = '1';
                item.CargoRepresentante = "-";
                item.IdEstadoRegistro = '1';
                item.FechaRegistro = DateTime.Now;
                item.IdFuenteFinanciamiento = Convert.ToInt32(FuenteFinanciamiento);
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            return PartialView("Create",item);
        }

        // GET: Planificacion/OrganismoFinanciador/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.OrganismoFinanciador.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var items = new List<SelectListItem>();
            items = DB.FuenteFinanciamiento.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdFuenteFinanciamiento.ToString()
                   }).
                   ToList();
            ViewBag.FuenteFinanciamiento = items;

            return PartialView( "Edit", item);
        }

        // POST: Planificacion/OrganismoFinanciador/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdOrganismoFinanciador,Descripcion,Sigla, IdFuenteFinanciamiento")] Models.Planificacion.OrganismoFinanciador item, string FuenteFinanciamiento)
        {
            if (id != item.IdOrganismoFinanciador)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.IdFuenteFinanciamiento = Convert.ToInt32(FuenteFinanciamiento);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdOrganismoFinanciador))
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

        // GET: Planificacion/OrganismoFinanciador/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.OrganismoFinanciador.FirstOrDefaultAsync(m => m.IdOrganismoFinanciador == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Planificacion/OrganismoFinanciador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.OrganismoFinanciador.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.OrganismoFinanciador.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.OrganismoFinanciador.Any(e => e.IdOrganismoFinanciador == id);
        }
    }
}
