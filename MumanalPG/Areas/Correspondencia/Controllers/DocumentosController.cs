using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models;
using MumanalPG.Models.RRHH;
using MumanalPG.Utility;
using NpgsqlTypes;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;
using Beneficiario = MumanalPG.Models.RRHH.Beneficiario;

namespace MumanalPG.Areas.Correspondencia.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Correspondencia")]
    public class DocumentosController : BaseController
    {        
        
		public DocumentosController(ApplicationDbContext db, UserManager<IdentityUser> userManager): base(db, userManager)
        {
            
        }

		// GET: Correspondencia/Documentos
        [Breadcrumb("Documentos", FromController = "Dashboard", FromAction = "Index")]
        public async Task<IActionResult> Index(string filter, int type, int page = 1, string sortExpression = "Referencia", string a = "")
        { 

            var consulta = DB.CorrespondenciaDocumento.AsNoTracking().AsQueryable();
            consulta = consulta.Where(m => (m.IdEstadoRegistro != Constantes.Anulado && m.Tipo.Id == type)); // el estado es diferente a ANULADO
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Referencia, $"%{filter}%"));
            }
            var resp = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"Referencia");
            resp.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            ViewBag.docTipoId = type;
            return View(resp);
        }

        // GET: Correspondencia/Documentos/Details/5
        public async Task<IActionResult> Details(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaDocumento.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Details",item);
        }

        // GET: Correspondencia/Documentos/Create
        public IActionResult Create()
        {
            
            var model = new Models.Correspondencia.Documento();
            return PartialView("_Create", model);
        }

        // POST: Correspondencia/Documentos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.Correspondencia.Documento item)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser currentUser = await GetCurrentUser();
                item.IdUsuario =  currentUser.IdUsuario;
                item.FechaRegistro = DateTime.Now;
                item.IdEstadoRegistro = Constantes.Registrado;
                DB.Add(item);
                await DB.SaveChangesAsync();
                
            }
            return PartialView("_Create",item);
        }

        // GET: Correspondencia/Documentos/Edit/5
        public async Task<IActionResult> Edit(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaDocumento.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return PartialView( "_Edit", item);
        }

        // POST: Correspondencia/Documentos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Int32 id, Models.Correspondencia.Documento item)
        {
            if (id != item.Id)
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
                    if (!ItemExists(item.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
            }
            return PartialView("_Edit", item);
        }

        // GET: Correspondencia/Documentos/Delete/5
        public async Task<IActionResult> Delete(Int32? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await DB.CorrespondenciaDocumento.FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            return PartialView("_Delete",item);
        }

        // POST: Correspondencia/Documentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int32 id)
        {
            var item = await DB.CorrespondenciaDocumento.FindAsync(id);
            item.IdEstadoRegistro = Constantes.Anulado;
            DB.CorrespondenciaDocumento.Update(item);
            await DB.SaveChangesAsync();
            return PartialView("_Delete",item);
        }

        public JsonResult GetFuncionarios(string filter = "")
        {
            if (filter.Length > 3)
            {
                var beneficiarios = DB.RRHH_Beneficiario
                    .Where(b => (b.IdEstadoRegistro != Constantes.Anulado || b.IdEstadoRegistro == null))
                    .Where(b => EF.Functions.ILike(b.Denominacion, "%" + filter + "%"))
                    .OrderBy(d => d.Denominacion).Take(20)
                    .Select(c => new {Id=c.IdBeneficiario, Nombre = c.Denominacion})
                    .ToList(); 
                System.Console.WriteLine("============================================================");
                System.Console.WriteLine(beneficiarios.Count);
                System.Console.WriteLine("============================================================");
                return Json(new {repositories = beneficiarios});
            }
            else
            {
                return Json(new {repositories = new {}});
            }
        }

        private bool ItemExists(Int32 id)
        {
            return DB.CorrespondenciaDocumento.Any(e => e.Id == id);
        }
    }
}
