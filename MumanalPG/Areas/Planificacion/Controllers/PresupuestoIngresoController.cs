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
    public class PresupuestoIngresoController : BaseController
    {        
        
		public PresupuestoIngresoController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Planificacion/PresupuestoIngreso
        [Breadcrumb("PresupuestoIngreso", FromController = "DashboardPlan", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "IdRubroIngreso", string a = "")
        { 
            var consulta = DB.PresupuestoIngreso.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    
            //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrEmpty(filter))
            //if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
                //consulta = consulta.Where(m =>  m.IdRubroIngreso.Equals(filter));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "IdRubroIngreso");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Planificacion/PresupuestoIngreso/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.PresupuestoIngreso.FirstOrDefaultAsync(m => m.IdPresupuestoIngreso  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Planificacion/PresupuestoIngreso/Create
        public IActionResult Create()
        {
            var model = new Models.Planificacion.PresupuestoIngreso();

            //OrganismoFinanciador
            var items = new List<SelectListItem>();
            items = DB.OrganismoFinanciador.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdOrganismoFinanciador.ToString()
                   }).
                   ToList();
            ViewBag.OrganismoFinanciador = items;

            //UnidadEjecutora
            var itemsU = new List<SelectListItem>();
            itemsU = DB.RRHH_UnidadEjecutora.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdUnidadEjecutora.ToString()
                   }).
                   ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //RubroIngreso
            var itemsP = new List<SelectListItem>();
            itemsP = DB.RubroIngreso.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdRubroIngreso.ToString()
                   }).
                   ToList();
            ViewBag.RubroIngreso = itemsP;
            //Fin Combos

            return PartialView("Create", model);
        }

        // POST: Planificacion/PresupuestoIngreso/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Planificacion.PresupuestoIngreso item, string OrganismoFinanciador, string UnidadEjecutora, string RubroIngreso)

        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.Gestion = "2019";

                item.PptoAdiciones = 0;
                item.PptoModificaciones = 0;
                item.PptoVigente = item.PptoFormulado;

                item.EjecucionDevengado = 0;
                item.EjecucionRecaudado = 0;
                item.EjecucionDevuelto = 0;

                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;

                item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                item.IdRubroIngreso = Convert.ToInt32(RubroIngreso);
                //
                var rubroIngreso = await DB.RubroIngreso.FirstOrDefaultAsync(m => m.IdRubroIngreso == item.IdRubroIngreso);
                if (rubroIngreso == null)
                {
                    item.Descripcion = "No Asignado";
                    return NotFound();
                }
                else
                {
                    item.Descripcion = rubroIngreso.Descripcion;
                }
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            return PartialView("Create",item);
        }

        // GET: Planificacion/PresupuestoIngreso/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.PresupuestoIngreso.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            //OrganismoFinanciador
            var items = new List<SelectListItem>();
            items = DB.OrganismoFinanciador.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdOrganismoFinanciador.ToString()
                   }).
                   ToList();
            ViewBag.OrganismoFinanciador = items;
            //IdUnidadEjecutora
            var itemsU = new List<SelectListItem>();
            itemsU = DB.RRHH_UnidadEjecutora.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdUnidadEjecutora.ToString()
                   }).
                   ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //IdRubroIngreso
            var itemsP = new List<SelectListItem>();
            itemsP = DB.RubroIngreso.
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdRubroIngreso.ToString()
                   }).
                   ToList();
            ViewBag.RubroIngreso = itemsP;
            //Fin Combos

            return PartialView( "Edit", item);
        }

        // POST: Planificacion/PresupuestoIngreso/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdPresupuestoIngreso,IdRubroIngreso,Sigla, IdOrganismoFinanciador,Descripcion")] Models.Planificacion.PresupuestoIngreso item, string OrganismoFinanciador, string UnidadEjecutora, string EstructuraProgramatica, string RubroIngreso)
        {
            if (id != item.IdPresupuestoIngreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                    item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                    item.IdRubroIngreso = Convert.ToInt32(RubroIngreso);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdPresupuestoIngreso))
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

        // GET: Planificacion/PresupuestoIngreso/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.PresupuestoIngreso.FirstOrDefaultAsync(m => m.IdPresupuestoIngreso == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Planificacion/PresupuestoIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.PresupuestoIngreso.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.PresupuestoIngreso.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.PresupuestoIngreso.Any(e => e.IdPresupuestoIngreso == id);
        }
    }
}
