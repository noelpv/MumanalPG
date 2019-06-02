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
    public class TipoAlmacenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TipoAlmacenController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/TipoAlmacen
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoAlmacen.ToListAsync());
        }

        // GET: Administra/TipoAlmacen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlmacen = await _context.TipoAlmacen
                .FirstOrDefaultAsync(m => m.IdTipoAlmacen == id);
            if (tipoAlmacen == null)
            {
                return NotFound();
            }

            return View(tipoAlmacen);
        }

        // GET: Administra/TipoAlmacen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/TipoAlmacen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoAlmacen,Descripcion,IdEstadoRegistro,IdUsuario,FechaRegistro")] TipoAlmacen tipoAlmacen)
        {
            if (ModelState.IsValid)
            {
                tipoAlmacen.FechaRegistro = DateTime.Now;
                tipoAlmacen.IdEstadoRegistro = '1';

                _context.Add(tipoAlmacen);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoAlmacen);
        }

        // GET: Administra/TipoAlmacen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlmacen = await _context.TipoAlmacen.FindAsync(id);
            if (tipoAlmacen == null)
            {
                return NotFound();
            }
            return View(tipoAlmacen);
        }

        // POST: Administra/TipoAlmacen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoAlmacen,Descripcion,IdEstadoRegistro,IdUsuario,FechaRegistro")] TipoAlmacen tipoAlmacen)
        {
            if (id != tipoAlmacen.IdTipoAlmacen)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoAlmacen);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoAlmacenExists(tipoAlmacen.IdTipoAlmacen))
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
            return View(tipoAlmacen);
        }

        // GET: Administra/TipoAlmacen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoAlmacen = await _context.TipoAlmacen
                .FirstOrDefaultAsync(m => m.IdTipoAlmacen == id);
            if (tipoAlmacen == null)
            {
                return NotFound();
            }

            return View(tipoAlmacen);
        }

        // POST: Administra/TipoAlmacen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoAlmacen = await _context.TipoAlmacen.FindAsync(id);
            _context.TipoAlmacen.Remove(tipoAlmacen);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoAlmacenExists(int id)
        {
            return _context.TipoAlmacen.Any(e => e.IdTipoAlmacen == id);
        }
    }
}
