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
    public class DocumentoClasificacionController : BaseController
    {        
        
		public DocumentoClasificacionController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Generales/DocumentoClasificacion
        [Breadcrumb("Clasificación de Documentos", FromController = "DashboardGenerales", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.DocumentoClasificacion.AsNoTracking().AsQueryable();
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

        // GET: Generales/DocumentoClasificacion/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.DocumentoClasificacion.FirstOrDefaultAsync(m => m.IdDocumentoClasificacion  == id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView("Details",item);
        }

        // GET: Generales/DocumentoClasificacion/Create
        public IActionResult Create()
        {
            var model = new Models.Generales.DocumentoClasificacion();
            return PartialView("Create", model);
        }

        // POST: Generales/DocumentoClasificacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Generales.DocumentoClasificacion item)
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
            return PartialView("Create",item);
        }

        // GET: Generales/DocumentoClasificacion/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.DocumentoClasificacion.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "Edit", item);
        }

        // POST: Generales/DocumentoClasificacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Generales.DocumentoClasificacion item)
        {
            if (id != item.IdDocumentoClasificacion)
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
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdDocumentoClasificacion))
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

        // GET: Generales/DocumentoClasificacion/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.DocumentoClasificacion.FirstOrDefaultAsync(m => m.IdDocumentoClasificacion == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Generales/DocumentoClasificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.DocumentoClasificacion.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.DocumentoClasificacion.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.DocumentoClasificacion.Any(e => e.IdDocumentoClasificacion == id);
        }
    }
}
