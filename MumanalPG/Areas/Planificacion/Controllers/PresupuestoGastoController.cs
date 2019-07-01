using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Dynamic;
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

namespace MumanalPG.Areas.Planificacion.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Planificacion")]
    public class PresupuestoGastoController : BaseController
    {        
        
		public PresupuestoGastoController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Planificacion/PresupuestoGasto
        [Breadcrumb("PresupuestoGasto", FromController = "DashboardPlan", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.PresupuestoGasto.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    
            //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrEmpty(filter))
            //if (!string.IsNullOrWhiteSpace(filter))
            {
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
                //consulta = consulta.Where(m =>  m.IdPartidaGasto.Equals(filter));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Planificacion/PresupuestoGasto/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.PresupuestoGasto.FirstOrDefaultAsync(m => m.IdPresupuestoGasto  == id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView("Details",item);
        }

        // GET: Planificacion/PresupuestoGasto/Create
        public IActionResult Create()
        {
            var model = new Models.Planificacion.PresupuestoGasto();

            //OrganismoFinanciador
            //var items = new List<SelectListItem>();
            //items = DB.OrganismoFinanciador.                   
            //       Select(c => new SelectListItem()
            //       {
            //           Text = c.Descripcion,
            //           Value = c.IdOrganismoFinanciador.ToString()
            //       }).
            //       ToList();
            var items = DB.OrganismoFinanciador.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.OrganismoFinanciador = items;
            //UnidadEjecutora
            //var itemsU = new List<SelectListItem>();
            //itemsU = DB.RRHH_UnidadEjecutora.
            //       Select(c => new SelectListItem()
            //       {
            //           Text = c.Descripcion,
            //           Value = c.IdUnidadEjecutora.ToString()
            //       }).
            //       ToList();
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //EstructuraProgramatica
            //var itemsE = new List<SelectListItem>();
            //itemsE = DB.EstructuraProgramatica.
            //       Select(c => new SelectListItem()
            //       {
            //           Text = c.Descripcion,
            //           Value = c.IdEstructuraProgramatica.ToString()
            //       }).
            //       ToList();
            var itemsE = DB.EstructuraProgramatica.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.EstructuraProgramatica = itemsE;

            //PartidaGasto
            //var itemsP = new List<SelectListItem>();
            //itemsP = DB.PartidaGasto.
            //       Select(c => new SelectListItem()
            //       {
            //           Text = c.Descripcion,
            //           Value = c.IdPartidaGasto.ToString()
            //       }).
            //       ToList();
            var itemsP = DB.PartidaGasto.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.PartidaGasto = itemsP;
            //Fin Combos

            return PartialView("Create", model);
        }

        // POST: Planificacion/PresupuestoGasto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(Models.Planificacion.PresupuestoGasto item, string OrganismoFinanciador, string UnidadEjecutora, string EstructuraProgramatica, string PartidaGasto)
        public async Task<IActionResult> Create(Models.Planificacion.PresupuestoGasto item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdBeneficiarioResponsable = currentUser.AspNetUserId;
                item.Gestion = "2019";
                item.IdBeneficiario = 0;

                //item.PptoFormulado = '0';
                item.PptoAdiciones = 0;
                item.PptoModificaciones = 0;
                item.PptoVigente = item.PptoFormulado;

                item.EjecucionCompromiso = 0;
                item.EjecucionDevengado = 0;
                item.EjecucionPagado = 0;
                item.EjecucionDevuelto = 0;

                item.EjecucionRevertido = 0;
                item.EjecucionAnulado = 0;

                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                //item.Gestion = string Year(DateTime.Now);
                
                item.IdUsuarioAprueba = 1;
                item.FechaAprueba = DateTime.Now;

                //item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                //item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                //item.IdEstructuraProgramatica = Convert.ToInt32(EstructuraProgramatica);
                //item.IdPartidaGasto = Convert.ToInt32(PartidaGasto);
                //
                var partidaGasto = await DB.PartidaGasto.FirstOrDefaultAsync(m => m.IdPartidaGasto == item.IdPartidaGasto);
                if (partidaGasto == null)
                {
                    item.Descripcion = "No Asignado";
                    return NotFound();
                }
                else
                {
                    item.Descripcion = partidaGasto.Descripcion;
                }
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            //item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
            //item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
            //item.IdEstructuraProgramatica = Convert.ToInt32(EstructuraProgramatica);
            //item.IdPartidaGasto = Convert.ToInt32(PartidaGasto);
            var items = DB.OrganismoFinanciador.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.OrganismoFinanciador = items;

            var itemsU = DB.RRHH_UnidadEjecutora .
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            var itemsE = DB.EstructuraProgramatica.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.EstructuraProgramatica = itemsE;

            var itemsP = DB.PartidaGasto.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.PartidaGasto = itemsP;

            return PartialView("Create",item);
        }

        // GET: Planificacion/PresupuestoGasto/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.PresupuestoGasto.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            //OrganismoFinanciador
            var items = DB.OrganismoFinanciador.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.OrganismoFinanciador = items;

            //UnidadEjecutora
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //EstructuraProgramatica
            var itemsE = DB.EstructuraProgramatica.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.EstructuraProgramatica = itemsE;

            //PartidaGasto
            var itemsP = DB.PartidaGasto.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.PartidaGasto = itemsP;
            //Fin Combos

            return PartialView( "Edit", item);
        }

        // POST: Planificacion/PresupuestoGasto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(Int32 id, [Bind("IdPresupuestoGasto,IdPartidaGasto,Sigla, IdOrganismoFinanciador,Descripcion")] Models.Planificacion.PresupuestoGasto item, string OrganismoFinanciador, string UnidadEjecutora, string EstructuraProgramatica, string PartidaGasto)
        public async Task<IActionResult> Edit(Int32 id, Models.Planificacion.PresupuestoGasto item)
        {
            if (id != item.IdPresupuestoGasto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    item.IdBeneficiarioResponsable = currentUser.AspNetUserId;
                    item.Gestion = "2019";
                    item.IdBeneficiario = 0;

                    item.PptoAdiciones = 0;
                    item.PptoModificaciones = 0;
                    item.PptoVigente = item.PptoFormulado;

                    item.EjecucionCompromiso = 0;
                    item.EjecucionDevengado = 0;
                    item.EjecucionPagado = 0;
                    item.EjecucionDevuelto = 0;

                    item.EjecucionRevertido = 0;
                    item.EjecucionAnulado = 0;

                    item.IdEstadoRegistro = 1;
                    item.FechaRegistro = DateTime.Now;
                    //item.Gestion = string Year(DateTime.Now);

                    item.IdUsuarioAprueba = 1;
                    item.FechaAprueba = DateTime.Now;

                    var partidaGasto = await DB.PartidaGasto.FirstOrDefaultAsync(m => m.IdPartidaGasto == item.IdPartidaGasto);
                    if (partidaGasto == null)
                    {
                        item.Descripcion = "No Asignado";
                        return NotFound();
                    }
                    else
                    {
                        item.Descripcion = partidaGasto.Descripcion;
                    }
                    //item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                    //item.IdUnidadEjecutora = Convert.ToInt32(UnidadEjecutora);
                    //item.IdEstructuraProgramatica = Convert.ToInt32(EstructuraProgramatica);
                    //item.IdPartidaGasto = Convert.ToInt32(PartidaGasto);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdPresupuestoGasto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            //OrganismoFinanciador
            var items = DB.OrganismoFinanciador.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.OrganismoFinanciador = items;

            //UnidadEjecutora
            var itemsU = DB.RRHH_UnidadEjecutora.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.UnidadEjecutora = itemsU;

            //EstructuraProgramatica
            var itemsE = DB.EstructuraProgramatica.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.EstructuraProgramatica = itemsE;

            //PartidaGasto
            var itemsP = DB.PartidaGasto.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            ViewBag.PartidaGasto = itemsP;
            //Fin Combos

            return PartialView("Edit", item);
        }

        // GET: Planificacion/PresupuestoGasto/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.PresupuestoGasto.FirstOrDefaultAsync(m => m.IdPresupuestoGasto == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Planificacion/PresupuestoGasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.PresupuestoGasto.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.PresupuestoGasto.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.PresupuestoGasto.Any(e => e.IdPresupuestoGasto == id);
        }
    }
}
