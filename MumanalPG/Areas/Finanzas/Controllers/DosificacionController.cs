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
    public class DosificacionController : BaseController
    {        
        
		public DosificacionController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

        // GET: Finanzas/Dosificacion
        //[Breadcrumb("Dosificacion", FromController = "DashboardPlan", FromAction = "Clasificadores")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "NumeroAutorizacion", string a = "")
        { 
            var consulta = DB.Dosificacion.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => m.IdEstadoRegistro != 2);    //!= Constantes.Eliminado); // != el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.NumeroAutorizacion, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression, "NumeroAutorizacion");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(resp);
        }

        // GET: Finanzas/Dosificacion/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Dosificacion.FirstOrDefaultAsync(m => m.IdDosificacion  == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Details",item);
        }

        // GET: Finanzas/Dosificacion/Create
        public IActionResult Create()
        {
            var model = new Models.Finanzas.Dosificacion();

            var items1 = new List<SelectListItem>();
            items1 = DB.DocumentoRespaldo.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdDocumentoRespaldo.ToString()
                   }).
                   ToList();
            ViewBag.DocumentoRespaldo = items1;
            
            var items2 = new List<SelectListItem>();
            items2 = DB.RRHH_Beneficiario.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.DocumentoIdentidad,
                       Value = c.IdBeneficiario.ToString()
                   }).
                   ToList();
            ViewBag.Beneficiario = items2;

            /* var items3 = new List<SelectListItem>();
            items3 = DB.RRHH_BeneficiarioResponsable.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdBeneficiarioResponsable.ToString()
                   }).
                   ToList();
            ViewBag.RRHH_BeneficiarioResponsable = items3; */

            return PartialView("Create", model);
        }

        // POST: Finanzas/Dosificacion/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Finanzas.Dosificacion item, string DocumentoRespaldo, string RRHH_Beneficiario)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario = currentUser.AspNetUserId;
                item.IdEstadoRegistro = '1';
                item.FechaRegistro = DateTime.Now;
                item.IdDocumentoRespaldo = Convert.ToInt32(DocumentoRespaldo);
                item.IdBeneficiario = Convert.ToInt32(RRHH_Beneficiario);
                // item.IdBeneficiarioResponsable = Convert.ToInt32(RRHH_BeneficiarioResponsable);
                DB.Add(item);
                await DB.SaveChangesAsync();
            }
            return PartialView("Create",item);
        }

        // GET: Finanzas/Dosificacion/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var item = await DB.Dosificacion.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            var items1 = new List<SelectListItem>();
            items1 = DB.DocumentoRespaldo.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdDocumentoRespaldo.ToString()
                   }).
                   ToList();
            ViewBag.DocumentoRespaldo = items1;
            
            var items2 = new List<SelectListItem>();
            items2 = DB.RRHH_Beneficiario.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.DocumentoIdentidad,
                       Value = c.IdBeneficiario.ToString()
                   }).
                   ToList();
            ViewBag.Beneficiario = items2;

            /* var items3 = new List<SelectListItem>();
            items3 = DB.RRHH_BeneficiarioResponsable.                   
                   Select(c => new SelectListItem()
                   {
                       Text = c.Descripcion,
                       Value = c.IdBeneficiarioResponsable.ToString()
                   }).
                   ToList();
            ViewBag.RRHH_BeneficiarioResponsable = items3; */

            return PartialView( "Edit", item);
        }

        // POST: Finanzas/Dosificacion/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, [Bind("IdDosificacion,NumeroAutorizacion, IdDocumentoRespaldo, IdTipoCuentaBanco, IdTipoMoneda, IdOrganismoFinanciador")] Models.Finanzas.Dosificacion item, string DocumentoRespaldo, string RRHH_Beneficiario)
        {
            if (id != item.IdDosificacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    item.IdDocumentoRespaldo = Convert.ToInt32(DocumentoRespaldo);
                    item.IdBeneficiario = Convert.ToInt32(RRHH_Beneficiario);
                // item.IdBeneficiarioResponsable = Convert.ToInt32(RRHH_BeneficiarioResponsable);
                    DB.Update(item);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ItemExists(item.IdDosificacion))
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

        // GET: Finanzas/Dosificacion/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.Dosificacion.FirstOrDefaultAsync(m => m.IdDosificacion == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("Delete",item);
        }

        // POST: Finanzas/Dosificacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.Dosificacion.FindAsync(id);
            item.IdEstadoRegistro = 2;  //Constantes.Eliminado ;
            DB.Dosificacion.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("Delete",item);
        }

        private bool ItemExists(Int32 id)
        {
            return DB.Dosificacion.Any(e => e.IdDosificacion == id);
        }
    }
}