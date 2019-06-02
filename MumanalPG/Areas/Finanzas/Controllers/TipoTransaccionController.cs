using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Finanzas;

namespace MumanalPG.Areas.Finanzas
{
    [Area("Finanzas")]
    public class TipoTransaccionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoTransaccionController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Finanzas/TipoTransaccion
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoTransaccion.ToListAsync());
        }

        // GET: Finanzas/TipoTransaccion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransaccion = await _context.TipoTransaccion
                .FirstOrDefaultAsync(m => m.IdTipoTransaccion == id);
            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            return View(tipoTransaccion);
        }

        // GET: Finanzas/TipoTransaccion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Finanzas/TipoTransaccion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoTransaccion, Descripcion, IdEstadoRegistro, IdUsuario, FechaRegistro")] TipoTransaccion tipoTransaccion)
        {
            if (ModelState.IsValid)
            {
                tipoTransaccion.FechaRegistro = DateTime.Now;
                tipoTransaccion.IdEstadoRegistro = '1';

                _context.Add(tipoTransaccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoTransaccion);
        }

        // GET: Finanzas/TipoTransaccion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransaccion = await _context.TipoTransaccion.FindAsync(id);
            if (tipoTransaccion == null)
            {
                return NotFound();
            }
            return View(tipoTransaccion);
        }

        // POST: Finanzas/TipoTransaccion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoTransaccion, Descripcion, IdEstadoRegistro, IdUsuario, FechaRegistro")] TipoTransaccion tipoTransaccion)
        {
            if (id != tipoTransaccion.IdTipoTransaccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoTransaccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoTransaccionExists(tipoTransaccion.IdTipoTransaccion))
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
            return View(tipoTransaccion);
        }

        // GET: Finanzas/TipoTransaccion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoTransaccion = await _context.TipoTransaccion
                .FirstOrDefaultAsync(m => m.IdTipoTransaccion == id);
            if (tipoTransaccion == null)
            {
                return NotFound();
            }

            return View(tipoTransaccion);
        }

        // POST: Finanzas/TipoTransaccion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoTransaccion = await _context.TipoTransaccion.FindAsync(id);
            _context.TipoTransaccion.Remove(tipoTransaccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoTransaccionExists(int id)
        {
            return _context.TipoTransaccion.Any(e => e.IdTipoTransaccion == id);
        }
    }
}
