using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Utility;
using ReflectionIT.Mvc.Paging;
using SmartBreadcrumbs;

namespace MumanalPG.Areas.Planificacion.Controllers
{
    //[Authorize(Roles = SD.SuperAdminEndUser)]
    [Area("Planificacion")]
    public class TipoBeneficiariosController : BaseController
    {        
		public TipoBeneficiariosController(ApplicationDbContext db): base(db)
        {
        }

		// GET: Planificacion/TipoBeneficiarios
        [Breadcrumb("Tipos de Beneficiario")]
        public async Task<IActionResult> Index(string filter, int page = 1, string sortExpression = "Denominacion", string a="")
        { 
            var consulta = DB.RRHHParam_TipoBeneficiario.AsNoTracking().AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(filter))
			{
                consulta = consulta.Where(m => EF.Functions.ILike(m.Denominacion, $"%{filter}%"));
            }
            var modelo = await PagingList.CreateAsync(consulta, Constantes.TamanoPaginacion, page, sortExpression,"Denominacion");
            modelo.RouteValue = new RouteValueDictionary {{ "filter", filter}};
            ShowFlash(a);
            return View(modelo);
        }

        // GET: Planificacion/TipoBeneficiarios/Details/5
        public async Task<IActionResult> Details(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.RRHHParam_TipoBeneficiario.FirstOrDefaultAsync(m => m.IdTipoBeneficiario == id);
            if (tipoBeneficiario == null)
            {
                return NotFound();
            }

            return PartialView("_Details",tipoBeneficiario);
        }

        // GET: Planificacion/TipoBeneficiarios/Create
        public IActionResult Create()
        {
            var model = new Models.RRHHParam.TipoBeneficiario();
            return PartialView("_Create", model);
        }

        // POST: Planificacion/TipoBeneficiarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Models.RRHHParam.TipoBeneficiario tipoBeneficiario)
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
        public async Task<IActionResult> Edit(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.RRHHParam_TipoBeneficiario.FindAsync(id);
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
        public async Task<IActionResult> Edit(Int16 id, [Bind("IdTipoBeneficiario,Denominacion,Activo")] Models.RRHHParam.TipoBeneficiario tipoBeneficiario)
        {
            if (id != tipoBeneficiario.IdTipoBeneficiario)
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
                    if (!TipoBeneficiarioExists(tipoBeneficiario.IdTipoBeneficiario))
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
        public async Task<IActionResult> Delete(Int16? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoBeneficiario = await DB.RRHHParam_TipoBeneficiario.FirstOrDefaultAsync(m => m.IdTipoBeneficiario == id);
            if (tipoBeneficiario == null)
            {
                return NotFound();
            }

            return PartialView("_Delete",tipoBeneficiario);
        }

        // POST: Planificacion/TipoBeneficiarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Int16 id)
        {
            var tipoBeneficiario = await DB.RRHHParam_TipoBeneficiario.FindAsync(id);
            DB.RRHHParam_TipoBeneficiario.Remove(tipoBeneficiario);
            await DB.SaveChangesAsync();
            SetFlashSuccess("Registro eliminado satisfactoriamente");
            return PartialView("_Delete",tipoBeneficiario);
        }

        private bool TipoBeneficiarioExists(Int16 id)
        {
            return DB.RRHHParam_TipoBeneficiario.Any(e => e.IdTipoBeneficiario == id);
        }
    }
}
