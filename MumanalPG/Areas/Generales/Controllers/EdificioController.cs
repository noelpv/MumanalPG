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
    public class EdificioController : BaseController
    {        
        
		public EdificioController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Generales/Edificio
        [Breadcrumb("Edificio", FromController = "DashboardGenerales", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.Edificio.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.EdificioTipoDB).Include(m => m.MunicipioDB).Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Generales/Edificio/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Edificio.Include(m => m.EdificioTipoDB).Include(m => m.MunicipioDB).Include(m => m.BarrioDB).Include(m => m.CalleDB).FirstOrDefaultAsync(m => m.IdEdificio  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Generales/Edificio/Create
        public IActionResult Create()
        {
            var model = new Models.Generales.Edificio();
            ViewBag.TipoEdificio = DB.EdificioTipo.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Create", model);
        }

        // POST: Generales/Edificio/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Generales.Edificio item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdBeneficiario = "0";
                item.IdBeneficiarioEmpresa = "0";
                item.ArchivoFotoCargado = "t";
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            ViewBag.TipoEdificio = DB.EdificioTipo.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Create",item);
        }

        // GET: Generales/Edificio/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Edificio.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            ViewBag.TipoEdificio = DB.EdificioTipo.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView( "Edit", item);
        }

        // POST: Generales/Edificio/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id,  Models.Generales.Edificio item)
        {
            if (id != item.IdEdificio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ApplicationUser currentUser = await GetCurrentUser();
                    item.IdUsuario = currentUser.AspNetUserId;
                    item.IdBeneficiario = "0";
                    item.IdBeneficiarioEmpresa = "0";
                    item.ArchivoFotoCargado = "t";
                    item.IdEstadoRegistro = 1;
                    item.FechaRegistro = DateTime.Now;
                    DB.Add(item);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdEdificio))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            ViewBag.TipoEdificio = DB.EdificioTipo.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Edit", item);
        }

        // GET: Generales/Edificio/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Edificio.FirstOrDefaultAsync(m => m.IdEdificio == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Generales/Edificio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Edificio.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Edificio.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Edificio.Any(e => e.IdEdificio == id);
        }
    }
}
