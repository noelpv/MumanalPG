using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Planificacion;

namespace MumanalPG.Areas.Planificacion
{
    [Area("Planificacion")]
    public class PresupuestoGastoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresupuestoGastoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/PresupuestoGasto
        public async Task<IActionResult> Index()
        {
            return View(await _context.PresupuestoGasto.ToListAsync());
        }

        // GET: Planificacion/PresupuestoGasto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoGasto = await _context.PresupuestoGasto
                .FirstOrDefaultAsync(m => m.IdPresupuestoGasto == id);
            if (presupuestoGasto == null)
            {
                return NotFound();
            }

            return View(presupuestoGasto);
        }

        // GET: Planificacion/PresupuestoGasto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/PresupuestoGasto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresupuestoGasto,Gestion,IdUnidadEjecutora,IdEstructuraProgramatica,IdOrganismoFinanciador,IdPartidaGasto,IdBeneficiario,IdBeneficiarioResponsable,IdDocumentoRespaldo,PptoFormulado,PptoAdiciones,PptoModificaciones,PptoVigente,EjecucionCompromiso,EjecucionDevengado,EjecucionPagado,EjecucionDevuelto,EjecucionRevertido,EjecucionAnulado,IdEstadoRegistro,IdEstadoPpto,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] PresupuestoGasto presupuestoGasto)
        {
            if (ModelState.IsValid)
            {
                presupuestoGasto.FechaRegistro = DateTime.Now;
                presupuestoGasto.FechaAprueba = DateTime.Now;
                presupuestoGasto.IdEstadoRegistro = '1';
                presupuestoGasto.IdEstadoPpto = '1';

                _context.Add(presupuestoGasto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presupuestoGasto);
        }

        // GET: Planificacion/PresupuestoGasto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoGasto = await _context.PresupuestoGasto.FindAsync(id);
            if (presupuestoGasto == null)
            {
                return NotFound();
            }
            return View(presupuestoGasto);
        }

        // POST: Planificacion/PresupuestoGasto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPresupuestoGasto,Gestion,IdUnidadEjecutora,IdEstructuraProgramatica,IdOrganismoFinanciador,IdPartidaGasto,IdBeneficiario,IdBeneficiarioResponsable,IdDocumentoRespaldo,PptoFormulado,PptoAdiciones,PptoModificaciones,PptoVigente,EjecucionCompromiso,EjecucionDevengado,EjecucionPagado,EjecucionDevuelto,EjecucionRevertido,EjecucionAnulado,IdEstadoRegistro,IdEstadoPpto,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] PresupuestoGasto presupuestoGasto)
        {
            if (id != presupuestoGasto.IdPresupuestoGasto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuestoGasto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoGastoExists(presupuestoGasto.IdPresupuestoGasto))
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
            return View(presupuestoGasto);
        }

        // GET: Planificacion/PresupuestoGasto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoGasto = await _context.PresupuestoGasto
                .FirstOrDefaultAsync(m => m.IdPresupuestoGasto == id);
            if (presupuestoGasto == null)
            {
                return NotFound();
            }

            return View(presupuestoGasto);
        }

        // POST: Planificacion/PresupuestoGasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuestoGasto = await _context.PresupuestoGasto.FindAsync(id);
            _context.PresupuestoGasto.Remove(presupuestoGasto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoGastoExists(int id)
        {
            return _context.PresupuestoGasto.Any(e => e.IdPresupuestoGasto == id);
        }
    }
}
