using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Administra;

namespace MumanalPG.Areas.Administra
{
    [Area("Administra")]
    public class ActivoAsignacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivoAsignacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/ActivoAsignacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivoAsignacion.ToListAsync());
        }

        // GET: Administra/ActivoAsignacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoAsignacion = await _context.ActivoAsignacion
                .FirstOrDefaultAsync(m => m.IdActivoFijo == id);
            if (activoAsignacion == null)
            {
                return NotFound();
            }

            return View(activoAsignacion);
        }

        // GET: Administra/ActivoAsignacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/ActivoAsignacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActivoFijo,IdAlmacenInventario,IdBienes,CodigoActivoFijo,CodigoAdministrativo,Descripcion,IdBeneficiario,FechaIncorporacion,Ufv,CostoInicial,DepreciacionAcumuladaInicial,FactorActualizacion,ValorActual,DepreciacionAcumulada,DepreciacionGestion,ValorNeto,TiempoVidaEnAnios,TiempoVidaEnDias,CodigoRube,IdOrganismoFinanciador,IdEstadoActivoFijo,IdEstadoRegistro,IdUsuario,FechaRegistro")] ActivoAsignacion activoAsignacion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activoAsignacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activoAsignacion);
        }

        // GET: Administra/ActivoAsignacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoAsignacion = await _context.ActivoAsignacion.FindAsync(id);
            if (activoAsignacion == null)
            {
                return NotFound();
            }
            return View(activoAsignacion);
        }

        // POST: Administra/ActivoAsignacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActivoFijo,IdAlmacenInventario,IdBienes,CodigoActivoFijo,CodigoAdministrativo,Descripcion,IdBeneficiario,FechaIncorporacion,Ufv,CostoInicial,DepreciacionAcumuladaInicial,FactorActualizacion,ValorActual,DepreciacionAcumulada,DepreciacionGestion,ValorNeto,TiempoVidaEnAnios,TiempoVidaEnDias,CodigoRube,IdOrganismoFinanciador,IdEstadoActivoFijo,IdEstadoRegistro,IdUsuario,FechaRegistro")] ActivoAsignacion activoAsignacion)
        {
            if (id != activoAsignacion.IdActivoFijo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activoAsignacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoAsignacionExists(activoAsignacion.IdActivoFijo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(activoAsignacion);
        }

        // GET: Administra/ActivoAsignacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoAsignacion = await _context.ActivoAsignacion
                .FirstOrDefaultAsync(m => m.IdActivoFijo == id);
            if (activoAsignacion == null)
            {
                return NotFound();
            }

            return View(activoAsignacion);
        }

        // POST: Administra/ActivoAsignacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activoAsignacion = await _context.ActivoAsignacion.FindAsync(id);
            _context.ActivoAsignacion.Remove(activoAsignacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivoAsignacionExists(int id)
        {
            return _context.ActivoAsignacion.Any(e => e.IdActivoFijo == id);
        }
    }
}
