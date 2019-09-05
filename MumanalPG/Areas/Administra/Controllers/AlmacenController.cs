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

namespace MumanalPG.Areas.Administra.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Administra")]
    public class AlmacenController : BaseController
    {        
        
		public AlmacenController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Administra/Almacen
        [Breadcrumb("Almacen", FromController = "DashboardAdministra", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "IdTipoAlmacen", string a = "")
        { 
            var consulta = DB.Almacen.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.TipoAlmacenDB)
                               .Include(m => m.BeneficiarioDB)
                               .Include(m => m.MunicipioDB)
                               .Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.TipoAlmacenDB.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "IdTipoAlmacen");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Administra/Almacen/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Almacen.Include(m => m.TipoAlmacenDB)
                                    .Include(m => m.BeneficiarioDB)
                                    .Include(m => m.MunicipioDB)
                                    .Include(m => m.BarrioDB)
                                    .Include(m => m.CalleDB)
                                    .FirstOrDefaultAsync(m => m.IdAlmacen  == id);
            
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Administra/Almacen/Create
        public IActionResult Create()
        {
            var model = new Models.Administra.Almacen();

            // Datos para las dropdownlist's
            ViewBag.TipoAlmacen = DB.TipoAlmacen.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();

            return PartialView("Create", model);
        }

        // POST: Administra/Almacen/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Administra.Almacen item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = 1;
                item.FechaRegistro = DateTime.Now;
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            // Datos para las dropdownlist's
            ViewBag.TipoAlmacen = DB.TipoAlmacen.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            return PartialView("Create",item);
        }

        // GET: Administra/Almacen/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Almacen
                .Include(m => m.BeneficiarioDB)
                .FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (item == null)
            {
                return NotFound();
            }
            // Para editar, cargamos el nombre del beneficiario
            item.NombreBeneficiario = item.BeneficiarioDB.Denominacion;

            // Datos para las dropdownlist's
            ViewBag.TipoAlmacen = DB.TipoAlmacen.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();

            return PartialView("Edit", item);
        }

        // POST: Administra/Almacen/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Administra.Almacen item)
        {
            if (id != item.IdAlmacen)
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
                    if (!ItemExists(item.IdAlmacen))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }    
            }

            // Datos para las dropdownlist's
            ViewBag.TipoAlmacen = DB.TipoAlmacen.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Municipio = DB.Municipio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Barrio = DB.Barrio.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.Calle = DB.Calle.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();

            return PartialView("Edit", item);
        }

        // GET: Administra/Almacen/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Almacen.FirstOrDefaultAsync(m => m.IdAlmacen == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Administra/Almacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Almacen.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Almacen.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Almacen.Any(e => e.IdAlmacen == id);
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
