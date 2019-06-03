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
    public class ActivoTransferenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivoTransferenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/ActivoTransferencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivoTransferencia.ToListAsync());
        }

        // GET: Administra/ActivoTransferencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoTransferencia = await _context.ActivoTransferencia
                .FirstOrDefaultAsync(m => m.IdActivoTransferencia == id);
            if (activoTransferencia == null)
            {
                return NotFound();
            }

            return View(activoTransferencia);
        }

        // GET: Administra/ActivoTransferencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/ActivoTransferencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActivoTransferencia,IdActivoFijo,IdAlmacen,IdAlmacenDestino,IdUnidadEjecutora,IdUnidadEjecutoraDestino,IdBeneficiario,IdBeneficiarioDestino,IdBeneficiarioEncargado,Observacion,FechaTransferencia,IdEstadoActivoFijo,IdEstadoRegistro,FechaRegistro,IdUsuario")] ActivoTransferencia activoTransferencia)
        {
            if (ModelState.IsValid)
            {
                activoTransferencia.FechaRegistro = DateTime.Now;
                activoTransferencia.IdEstadoRegistro = '1';

                _context.Add(activoTransferencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activoTransferencia);
        }

        // GET: Administra/ActivoTransferencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoTransferencia = await _context.ActivoTransferencia.FindAsync(id);
            if (activoTransferencia == null)
            {
                return NotFound();
            }
            return View(activoTransferencia);
        }

        // POST: Administra/ActivoTransferencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActivoTransferencia,IdActivoFijo,IdAlmacen,IdAlmacenDestino,IdUnidadEjecutora,IdUnidadEjecutoraDestino,IdBeneficiario,IdBeneficiarioDestino,IdBeneficiarioEncargado,Observacion,FechaTransferencia,IdEstadoActivoFijo,IdEstadoRegistro,FechaRegistro,IdUsuario")] ActivoTransferencia activoTransferencia)
        {
            if (id != activoTransferencia.IdActivoTransferencia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activoTransferencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoTransferenciaExists(activoTransferencia.IdActivoTransferencia))
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
            return View(activoTransferencia);
        }

        // GET: Administra/ActivoTransferencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoTransferencia = await _context.ActivoTransferencia
                .FirstOrDefaultAsync(m => m.IdActivoTransferencia == id);
            if (activoTransferencia == null)
            {
                return NotFound();
            }

            return View(activoTransferencia);
        }

        // POST: Administra/ActivoTransferencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activoTransferencia = await _context.ActivoTransferencia.FindAsync(id);
            _context.ActivoTransferencia.Remove(activoTransferencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivoTransferenciaExists(int id)
        {
            return _context.ActivoTransferencia.Any(e => e.IdActivoTransferencia == id);
        }
    }
}
