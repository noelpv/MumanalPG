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
    public class PresupuestoModificacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PresupuestoModificacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/PresupuestoModificaciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.PresupuestoModificaciones.ToListAsync());
        }

        // GET: Planificacion/PresupuestoModificaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoModificaciones = await _context.PresupuestoModificaciones
                .FirstOrDefaultAsync(m => m.IdPresupuestoModificaciones == id);
            if (presupuestoModificaciones == null)
            {
                return NotFound();
            }

            return View(presupuestoModificaciones);
        }

        // GET: Planificacion/PresupuestoModificaciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/PresupuestoModificaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPresupuestoModificaciones,Gestion,IdDocumentoRespaldo,NumeroRespaldo,FechaAutorizacion,IdPoa,IdPresupuestoGasto,MontoOrigen,IdPoaDestino,IdPresupuestoGastoDestino,MontoDestino,IdEstadoRegistro,IdUsuario,FechaRegistro")] PresupuestoModificaciones presupuestoModificaciones)
        {
            if (ModelState.IsValid)
            {
                presupuestoModificaciones.FechaRegistro = DateTime.Now;
                presupuestoModificaciones.IdEstadoRegistro = '1';
                
                _context.Add(presupuestoModificaciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(presupuestoModificaciones);
        }

        // GET: Planificacion/PresupuestoModificaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoModificaciones = await _context.PresupuestoModificaciones.FindAsync(id);
            if (presupuestoModificaciones == null)
            {
                return NotFound();
            }
            return View(presupuestoModificaciones);
        }

        // POST: Planificacion/PresupuestoModificaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPresupuestoModificaciones,Gestion,IdDocumentoRespaldo,NumeroRespaldo,FechaAutorizacion,IdPoa,IdPresupuestoGasto,MontoOrigen,IdPoaDestino,IdPresupuestoGastoDestino,MontoDestino,IdEstadoRegistro,IdUsuario,FechaRegistro")] PresupuestoModificaciones presupuestoModificaciones)
        {
            if (id != presupuestoModificaciones.IdPresupuestoModificaciones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(presupuestoModificaciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PresupuestoModificacionesExists(presupuestoModificaciones.IdPresupuestoModificaciones))
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
            return View(presupuestoModificaciones);
        }

        // GET: Planificacion/PresupuestoModificaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var presupuestoModificaciones = await _context.PresupuestoModificaciones
                .FirstOrDefaultAsync(m => m.IdPresupuestoModificaciones == id);
            if (presupuestoModificaciones == null)
            {
                return NotFound();
            }

            return View(presupuestoModificaciones);
        }

        // POST: Planificacion/PresupuestoModificaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var presupuestoModificaciones = await _context.PresupuestoModificaciones.FindAsync(id);
            _context.PresupuestoModificaciones.Remove(presupuestoModificaciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PresupuestoModificacionesExists(int id)
        {
            return _context.PresupuestoModificaciones.Any(e => e.IdPresupuestoModificaciones == id);
        }
    }
}
