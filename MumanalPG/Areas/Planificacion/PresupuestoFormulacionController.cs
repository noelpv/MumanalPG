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
    public class PresupuestoFormulacionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresupuestoFormulacionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/PresupuestoFormulacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.PresupuestoFormulacion.ToListAsync());
        }

        // GET: Planificacion/PresupuestoFormulacion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoFormulacion = await _context.PresupuestoFormulacion
                .FirstOrDefaultAsync(m => m.IdPresupuestoFormulacion == id);
            if (presupuestoFormulacion == null)
            {
                return NotFound();
            }

            return View(presupuestoFormulacion);
        }

        // GET: Planificacion/PresupuestoFormulacion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/PresupuestoFormulacion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresupuestoFormulacion,Gestion,IdUnidadEjecutora,IdEstructuraProgramatica,IdOrganismoFinanciador,IdPartidaGasto,IdBeneficiario,IdBeneficiarioResponsable,IdDocumentoRespaldo,PptoFormulado,PptoAdiciones,PptoModificaciones,PptoVigente,EjecucionCompromiso,EjecucionDevengado,EjecucionPagado,EjecucionDevuelto,EjecucionRevertido,EjecucionAnulado,IdEstadoRegistro,IdEstadoPpto,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] PresupuestoFormulacion presupuestoFormulacion)
        {
            if (ModelState.IsValid)
            {
                presupuestoFormulacion.FechaRegistro = DateTime.Now;
                presupuestoFormulacion.FechaAprueba = DateTime.Now;
                presupuestoFormulacion.IdEstadoRegistro = '1';
                presupuestoFormulacion.IdEstadoPpto = '1';

                _context.Add(presupuestoFormulacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presupuestoFormulacion);
        }

        // GET: Planificacion/PresupuestoFormulacion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoFormulacion = await _context.PresupuestoFormulacion.FindAsync(id);
            if (presupuestoFormulacion == null)
            {
                return NotFound();
            }
            return View(presupuestoFormulacion);
        }

        // POST: Planificacion/PresupuestoFormulacion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPresupuestoFormulacion,Gestion,IdUnidadEjecutora,IdEstructuraProgramatica,IdOrganismoFinanciador,IdPartidaGasto,IdBeneficiario,IdBeneficiarioResponsable,IdDocumentoRespaldo,PptoFormulado,PptoAdiciones,PptoModificaciones,PptoVigente,EjecucionCompromiso,EjecucionDevengado,EjecucionPagado,EjecucionDevuelto,EjecucionRevertido,EjecucionAnulado,IdEstadoRegistro,IdEstadoPpto,IdUsuario,IdUsuarioAprueba,FechaRegistro,FechaAprueba")] PresupuestoFormulacion presupuestoFormulacion)
        {
            if (id != presupuestoFormulacion.IdPresupuestoFormulacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuestoFormulacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoFormulacionExists(presupuestoFormulacion.IdPresupuestoFormulacion))
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
            return View(presupuestoFormulacion);
        }

        // GET: Planificacion/PresupuestoFormulacion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoFormulacion = await _context.PresupuestoFormulacion
                .FirstOrDefaultAsync(m => m.IdPresupuestoFormulacion == id);
            if (presupuestoFormulacion == null)
            {
                return NotFound();
            }

            return View(presupuestoFormulacion);
        }

        // POST: Planificacion/PresupuestoFormulacion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuestoFormulacion = await _context.PresupuestoFormulacion.FindAsync(id);
            _context.PresupuestoFormulacion.Remove(presupuestoFormulacion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoFormulacionExists(int id)
        {
            return _context.PresupuestoFormulacion.Any(e => e.IdPresupuestoFormulacion == id);
        }
    }
}
