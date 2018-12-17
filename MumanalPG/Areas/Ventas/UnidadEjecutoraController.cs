using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class UnidadEjecutoraController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UnidadEjecutoraController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/UnidadEjecutora
        public async Task<IActionResult> Index()
        {
            return View(await _context.UnidadEjecutora.ToListAsync());
        }

        // GET: Ventas/UnidadEjecutora/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadEjecutora = await _context.UnidadEjecutora
                .FirstOrDefaultAsync(m => m.IdUnidadEjecutora == id);
            if (unidadEjecutora == null)
            {
                return NotFound();
            }

            return View(unidadEjecutora);
        }

        // GET: Ventas/UnidadEjecutora/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/UnidadEjecutora/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUnidadEjecutora,Descripcion,Sigla,IdUnidadEjecutoraPadre,Nivel,EsUltimoNivel,IdDepartamento,Gestion,IdEstadoRegistro,IdUsuario,FechaRegistro")] UnidadEjecutora unidadEjecutora)
        {
            if (ModelState.IsValid)
            {
                _context.Add(unidadEjecutora);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(unidadEjecutora);
        }

        // GET: Ventas/UnidadEjecutora/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadEjecutora = await _context.UnidadEjecutora.FindAsync(id);
            if (unidadEjecutora == null)
            {
                return NotFound();
            }
            return View(unidadEjecutora);
        }

        // POST: Ventas/UnidadEjecutora/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUnidadEjecutora,Descripcion,Sigla,IdUnidadEjecutoraPadre,Nivel,EsUltimoNivel,IdDepartamento,Gestion,IdEstadoRegistro,IdUsuario,FechaRegistro")] UnidadEjecutora unidadEjecutora)
        {
            if (id != unidadEjecutora.IdUnidadEjecutora)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(unidadEjecutora);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UnidadEjecutoraExists(unidadEjecutora.IdUnidadEjecutora))
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
            return View(unidadEjecutora);
        }

        // GET: Ventas/UnidadEjecutora/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var unidadEjecutora = await _context.UnidadEjecutora
                .FirstOrDefaultAsync(m => m.IdUnidadEjecutora == id);
            if (unidadEjecutora == null)
            {
                return NotFound();
            }

            return View(unidadEjecutora);
        }

        // POST: Ventas/UnidadEjecutora/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var unidadEjecutora = await _context.UnidadEjecutora.FindAsync(id);
            _context.UnidadEjecutora.Remove(unidadEjecutora);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UnidadEjecutoraExists(int id)
        {
            return _context.UnidadEjecutora.Any(e => e.IdUnidadEjecutora == id);
        }
    }
}
