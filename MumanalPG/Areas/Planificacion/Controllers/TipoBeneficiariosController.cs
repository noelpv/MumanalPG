using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Planificacion;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Planificacion.Controllers
{
    [Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Planificacion")]
    public class TipoBeneficiariosController : BaseController
    {
        
       public TipoBeneficiariosController(ApplicationDbContext db): base(db)
        {
        }

        // GET: Planificacion/TipoBeneficiarios
        [Breadcrumb("Tipos de Beneficiario")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Denominacion")
        {
 
            var consulta = DB.TipoBeneficiario.AsNoTracking()
                .AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(filter)) {
                consulta = consulta.Where(m => EF.Functions.ILike(m.Denominacion, $"%{filter}%"));
            }
            var modelo = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"Denominacion");
            modelo.RouteValue = new RouteValueDictionary {
                { "filter", filter}
            };
            return View(modelo);
        }

        // GET: Planificacion/TipoBeneficiarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.TipoBeneficiario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoBeneficiario == null)
            {
                return NotFound();
            }

            return PartialView("_Details",tipoBeneficiario);
        }

        // GET: Planificacion/TipoBeneficiarios/Create
        public IActionResult Create()
        {
            var model = new TipoBeneficiario();
            return PartialView("_Create", model);
        }

        // POST: Planificacion/TipoBeneficiarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TipoBeneficiario tipoBeneficiario)
        {
            if (ModelState.IsValid)
            {
                DB.Add(tipoBeneficiario);
                await DB.SaveChangesAsync();
                SetFlashSuccess("Registro creado satisfactoriamente");
            }
            return PartialView("_Create",tipoBeneficiario);
        }

        // GET: Planificacion/TipoBeneficiarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.TipoBeneficiario.FindAsync(id);
            if (tipoBeneficiario == null)
            {
                return NotFound();
            }
            return PartialView( "_Edit", tipoBeneficiario);
        }

        // POST: Planificacion/TipoBeneficiarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Denominacion,Activo")] TipoBeneficiario tipoBeneficiario)
        {
            if (id != tipoBeneficiario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    DB.Update(tipoBeneficiario);
                    await DB.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoBeneficiarioExists(tipoBeneficiario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                SetFlashSuccess("Registro modificado satisfactoriamente");
            }
            return PartialView("_Edit", tipoBeneficiario);
        }

        // GET: Planificacion/TipoBeneficiarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.TipoBeneficiario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoBeneficiario == null)
            {
                return NotFound();
            }

            return PartialView("_Delete",tipoBeneficiario);
        }

        // POST: Planificacion/TipoBeneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoBeneficiario = await DB.TipoBeneficiario.FindAsync(id);
            DB.TipoBeneficiario.Remove(tipoBeneficiario);
            await DB.SaveChangesAsync();
            SetFlashSuccess("Registro eliminado satisfactoriamente");
            return PartialView("_Delete",tipoBeneficiario);
        }

        private bool TipoBeneficiarioExists(int id)
        {
            return DB.TipoBeneficiario.Any(e => e.Id == id);
        }
    }
}
