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
    public class InstruccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstruccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/Instrucciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Instrucciones.ToListAsync());
        }

        // GET: Planificacion/Instrucciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrucciones = await _context.Instrucciones
                .FirstOrDefaultAsync(m => m.IdInstruccion == id);
            if (instrucciones == null)
            {
                return NotFound();
            }

            return View(instrucciones);
        }

        // GET: Planificacion/Instrucciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/Instrucciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInstruccion,Descripcion,IdEstadoRegistro,IdUsuario,FechaRegistro")] Instrucciones instrucciones)
        {
            if (ModelState.IsValid)
            {
                instrucciones.FechaRegistro = DateTime.Now;
                instrucciones.IdEstadoRegistro = '1';

                _context.Add(instrucciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instrucciones);
        }

        // GET: Planificacion/Instrucciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrucciones = await _context.Instrucciones.FindAsync(id);
            if (instrucciones == null)
            {
                return NotFound();
            }
            return View(instrucciones);
        }

        // POST: Planificacion/Instrucciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInstruccion,Descripcion,IdEstadoRegistro,IdUsuario,FechaRegistro")] Instrucciones instrucciones)
        {
            if (id != instrucciones.IdInstruccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrucciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstruccionesExists(instrucciones.IdInstruccion))
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
            return View(instrucciones);
        }

        // GET: Planificacion/Instrucciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instrucciones = await _context.Instrucciones
                .FirstOrDefaultAsync(m => m.IdInstruccion == id);
            if (instrucciones == null)
            {
                return NotFound();
            }

            return View(instrucciones);
        }

        // POST: Planificacion/Instrucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instrucciones = await _context.Instrucciones.FindAsync(id);
            _context.Instrucciones.Remove(instrucciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstruccionesExists(int id)
        {
            return _context.Instrucciones.Any(e => e.IdInstruccion == id);
        }
    }
}
