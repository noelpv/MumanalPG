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
    public class BienesController : BaseController
    {        
        
		public BienesController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Administra/Bienes
        [Breadcrumb("Bienes", FromController = "DashboardAdministra", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.Bienes.AsNoTracking().AsQueryable();
            consulta = consulta.Include(m => m.UnidadMedidaDB).Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
                                                                        // .Include(m => m.PartidaGasto)
                                                                        // Include(m => m.Descripcion)
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Descripcion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "Descripcion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Administra/Bienes/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Bienes.Include(m => m.PartidaGastoDB).Include(m => m.UnidadMedidaDB).FirstOrDefaultAsync(m => m.IdBienes  == id);
            // .Include(m => m.PartidaGastoDB)            
            // .Include(m => m.Descripcion)
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Administra/Bienes/Create
        public IActionResult Create()
        {
            var model = new Models.Administra.Bienes();

            var items1 = DB.UnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.UnidadMedida = items1;

            return PartialView("Create", model);
        }

        // POST: Administra/Bienes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Administra.Bienes item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = 1;
                item.IdEstadoVigente = 1;
                item.FechaRegistro = DateTime.Now;
                item.IdUnidadMedidaEmpaque = 0;

                item.IdModelo = 0;
                item.IdPais = 1;
                item.CodigoBienAnterior = "";
                item.DescripcionAnterior = "";
                item.IdRotacionBien = 0;

                item.PathArchivo = "";
                item.Kit = 0;
                item.StockMinimo = 0;
                item.StockInicial = 0;
                item.StockIngreso = 0;

                item.StockSalida = 0;
                item.StockActual = 0;
                item.PrecioReferenciaCompra = 0;
                item.PrecioVentaBase = 0;
                item.PrecioVentaFinal = 0;

                item.TotalAcumuladoCompraBs = 0;
                item.TotalAcumuladoVentaBs = 0;
                item.TotalUtilidadBs = 0;

                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            var items1 = DB.UnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.UnidadMedida = items1;

            return PartialView("Create",item);
        }

        // GET: Administra/Bienes/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Bienes
                .Include(m => m.PartidaGastoDB)
                .FirstOrDefaultAsync(m => m.IdBienes == id);
            if (item == null)
            {
                return NotFound();
            }

            item.NombrePartidaGasto = item.PartidaGastoDB.Descripcion;
            //var itemsP = DB.PartidaGasto.
            //    Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList();
            //ViewBag.PartidaGasto = itemsP;

            ViewBag.UnidadMedida = DB.UnidadMedida.Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i => i.Descripcion).ToList(); ;

            return PartialView("Edit", item);
        }

        // POST: Administra/Bienes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Administra.Bienes item)
        {
            if (id != item.IdBienes)
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
                    item.IdEstadoVigente = 1;
                    item.FechaRegistro = DateTime.Now;
                    item.IdUnidadMedidaEmpaque = 0;

                    item.IdModelo = 0;
                    item.IdPais = 1;
                    item.CodigoBienAnterior = "";
                    item.DescripcionAnterior = "";
                    item.IdRotacionBien = 0;

                    item.PathArchivo = "";
                    item.Kit = 0;
                    item.StockMinimo = 0;
                    item.StockInicial = 0;
                    item.StockIngreso = 0;

                    item.StockSalida = 0;
                    item.StockActual = 0;
                    item.PrecioReferenciaCompra = 0;
                    item.PrecioVentaBase = 0;
                    item.PrecioVentaFinal = 0;

                    item.TotalAcumuladoCompraBs = 0;
                    item.TotalAcumuladoVentaBs = 0;
                    item.TotalUtilidadBs = 0;

                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdBienes))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            var items1 = DB.UnidadMedida.
                Where(i => i.IdEstadoRegistro != Constantes.Anulado).OrderBy(i =>i.Descripcion).ToList();
            ViewBag.UnidadMedida = items1;
            return PartialView("Edit", item);
        }

        // GET: Administra/Bienes/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Bienes.FirstOrDefaultAsync(m => m.IdBienes == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Administra/Bienes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Bienes.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Bienes.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Bienes.Any(e => e.IdBienes == id);
        }

        public JsonResult ListaPartidaGastos(string filter = "")
        {
            if (filter.Length > 2)
            {
                // || EF.Functions.ILike(b.IdPartidaGasto, "%" + filter + "%")
                // || b.IdEstadoRegistro == null)
                var listaBenef = DB.PartidaGasto
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado ))
                    .Where(b => EF.Functions.ILike(b.Descripcion, "%" + filter + "%") )
                    .OrderBy(d => d.Descripcion).Take(20)
                    .Select(c => new {Id=c.IdPartidaGasto, Nombre = c.Descripcion})
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
