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

namespace MumanalPG.Areas.Generales.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Generales")]
    public class DocumentoRespaldoController : BaseController
    {        
        
		public DocumentoRespaldoController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Generales/DocumentoRespaldo
        //[Breadcrumb("DocumentoRespaldo", FromController = "DashboardPlan", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.DocumentoRespaldo.AsNoTracking().AsQueryable();
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

        // GET: Generales/DocumentoRespaldo/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.DocumentoRespaldo.FirstOrDefaultAsync(m => m.IdDocumentoRespaldo  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Generales/DocumentoRespaldo/Create
        public IActionResult Create()
        {
            var model = new Models.Generales.DocumentoRespaldo();
            //ini combo
            var items1 = DB.DocumentoClasificacion.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoClasificacion = items1;
            var items2 = DB.FrecuenciaUso.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.FrecuenciaUso = items2;
            var items3 = DB.DocumentoFormato.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoFormato = items3;
            //fin combo
            return PartialView("Create", model);
        }

        // POST: Generales/DocumentoRespaldo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Generales.DocumentoRespaldo item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                item.IdProceso=0;
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            var items1 = DB.DocumentoClasificacion.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoClasificacion = items1;
            var items2 = DB.FrecuenciaUso.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.FrecuenciaUso = items2;
            var items3 = DB.DocumentoFormato.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoFormato = items3;
            return PartialView("Create",item);
        }

        // GET: Generales/DocumentoRespaldo/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.DocumentoRespaldo.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            var items1 = DB.DocumentoClasificacion.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoClasificacion = items1;
            var items2 = DB.FrecuenciaUso.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.FrecuenciaUso = items2;
            var items3 = DB.DocumentoFormato.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoFormato = items3;
            return PartialView( "Edit", item);
        }

        // POST: Generales/DocumentoRespaldo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id,  Models.Generales.DocumentoRespaldo item)
        {
            if (id != item.IdDocumentoRespaldo)
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
                    if (!ItemExists(item.IdDocumentoRespaldo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            var items1 = DB.DocumentoClasificacion.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoClasificacion = items1;
            var items2 = DB.FrecuenciaUso.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.FrecuenciaUso = items2;
            var items3 = DB.DocumentoFormato.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.DocumentoFormato = items3;
            return PartialView("Edit", item);
        }

        // GET: Generales/DocumentoRespaldo/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.DocumentoRespaldo.FirstOrDefaultAsync(m => m.IdDocumentoRespaldo == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Generales/DocumentoRespaldo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.DocumentoRespaldo.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.DocumentoRespaldo.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.DocumentoRespaldo.Any(e => e.IdDocumentoRespaldo == id);
        }
    }
}
