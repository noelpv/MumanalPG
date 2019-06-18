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

namespace MumanalPG.Areas.Finanzas.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Authorize]
    [Area("Finanzas")]
    public class CuentaBancariaController : BaseController
    {        
        
		public CuentaBancariaController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Finanzas/CuentaBancaria
        //[Breadcrumb("CuentaBancaria", FromController = "DashboardPlan", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Descripcion", string a = "")
        { 
            var consulta = DB.CuentaBancaria.AsNoTracking().AsQueryable();
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

        // GET: Finanzas/CuentaBancaria/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CuentaBancaria.FirstOrDefaultAsync(m => m.IdCuentaBancaria  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/CuentaBancaria/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.CuentaBancaria();

            var items1 = new List<SelectListItem>();
            items1 = DB.Banco.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdBanco.ToString()
                   }).
                   ToList();
            ViewBag.Banco = items1;
            
            var items2 = new List<SelectListItem>();
            items2 = DB.TipoCuentaBanco.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdTipoCuentaBanco.ToString()
                   }).
                   ToList();
            ViewBag.TipoCuentaBanco = items2;

            var items3 = new List<SelectListItem>();
            items3 = DB.TipoMoneda.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdTipoMoneda.ToString()
                   }).
                   ToList();
            ViewBag.TipoMoneda = items3;

            var items4 = new List<SelectListItem>();
            items4 = DB.OrganismoFinanciador.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdOrganismoFinanciador.ToString()
                   }).
                   ToList();
            ViewBag.OrganismoFinanciador = items4;

            return PartialView("Create", model);
        }

        // POST: Finanzas/CuentaBancaria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.CuentaBancaria item, string Banco, string TipoCuentaBanco, string TipoMoneda, string OrganismoFinanciador)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = '1';
                item.FechaRegistro = DateTime.Now;
                item.IdBanco = Convert.ToInt32(Banco);
                item.IdTipoCuentaBanco = Convert.ToInt32(TipoCuentaBanco);
                item.IdTipoMoneda = Convert.ToInt32(TipoMoneda);
                item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            return PartialView("Create",item);
        }

        // GET: Finanzas/CuentaBancaria/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.CuentaBancaria.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var items1 = new List<SelectListItem>();
            items1 = DB.Banco.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdBanco.ToString()
                   }).
                   ToList();
            ViewBag.Banco = items1;
            
            var items2 = new List<SelectListItem>();
            items2 = DB.TipoCuentaBanco.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdTipoCuentaBanco.ToString()
                   }).
                   ToList();
            ViewBag.TipoCuentaBanco = items2;

            var items3 = new List<SelectListItem>();
            items3 = DB.TipoMoneda.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdTipoMoneda.ToString()
                   }).
                   ToList();
            ViewBag.TipoMoneda = items3;

            var items4 = new List<SelectListItem>();
            items4 = DB.OrganismoFinanciador.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdOrganismoFinanciador.ToString()
                   }).
                   ToList();
            ViewBag.OrganismoFinanciador = items4;

            return PartialView( "Edit", item);
        }

        // POST: Finanzas/CuentaBancaria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdCuentaBancaria,Descripcion,Sigla, IdBanco, IdTipoCuentaBanco, IdTipoMoneda, IdOrganismoFinanciador")] Models.Finanzas.CuentaBancaria item, string Banco, string TipoCuentaBanco, string TipoMoneda, string OrganismoFinanciador)
        {
            if (id != item.IdCuentaBancaria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.IdBanco = Convert.ToInt32(Banco);
                    item.IdTipoCuentaBanco = Convert.ToInt32(TipoCuentaBanco);
                    item.IdTipoMoneda = Convert.ToInt32(TipoMoneda);
                    item.IdOrganismoFinanciador = Convert.ToInt32(OrganismoFinanciador);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdCuentaBancaria))
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

        // GET: Finanzas/CuentaBancaria/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CuentaBancaria.FirstOrDefaultAsync(m => m.IdCuentaBancaria == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/CuentaBancaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.CuentaBancaria.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.CuentaBancaria.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.CuentaBancaria.Any(e => e.IdCuentaBancaria == id);
        }
    }
}
