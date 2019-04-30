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
    public class HojaRutaInstruccionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HojaRutaInstruccionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/HojaRutaInstrucciones
        public async Task<IActionResult> Index()
        {
            return View(await _context.HojaRutaInstrucciones.ToListAsync());
        }

        // GET: Planificacion/HojaRutaInstrucciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaInstrucciones = await _context.HojaRutaInstrucciones
                .FirstOrDefaultAsync(m => m.IdHojaRutaInstruccion == id);
            if (hojaRutaInstrucciones == null)
            {
                return NotFound();
            }

            return View(hojaRutaInstrucciones);
        }

        // GET: Planificacion/HojaRutaInstrucciones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/HojaRutaInstrucciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHojaRutaInstruccion,IdHojaRutaDetalle,IdInstruccion,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaInstrucciones hojaRutaInstrucciones)
        {
            if (ModelState.IsValid)
            {
                hojaRutaInstrucciones.FechaRegistro = DateTime.Now;
                hojaRutaInstrucciones.IdEstadoRegistro = '1';

                _context.Add(hojaRutaInstrucciones);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hojaRutaInstrucciones);
        }

        // GET: Planificacion/HojaRutaInstrucciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaInstrucciones = await _context.HojaRutaInstrucciones.FindAsync(id);
            if (hojaRutaInstrucciones == null)
            {
                return NotFound();
            }
            return View(hojaRutaInstrucciones);
        }

        // POST: Planificacion/HojaRutaInstrucciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHojaRutaInstruccion,IdHojaRutaDetalle,IdInstruccion,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaInstrucciones hojaRutaInstrucciones)
        {
            if (id != hojaRutaInstrucciones.IdHojaRutaInstruccion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojaRutaInstrucciones);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojaRutaInstruccionesExists(hojaRutaInstrucciones.IdHojaRutaInstruccion))
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
            return View(hojaRutaInstrucciones);
        }

        // GET: Planificacion/HojaRutaInstrucciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaInstrucciones = await _context.HojaRutaInstrucciones
                .FirstOrDefaultAsync(m => m.IdHojaRutaInstruccion == id);
            if (hojaRutaInstrucciones == null)
            {
                return NotFound();
            }

            return View(hojaRutaInstrucciones);
        }

        // POST: Planificacion/HojaRutaInstrucciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojaRutaInstrucciones = await _context.HojaRutaInstrucciones.FindAsync(id);
            _context.HojaRutaInstrucciones.Remove(hojaRutaInstrucciones);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojaRutaInstruccionesExists(int id)
        {
            return _context.HojaRutaInstrucciones.Any(e => e.IdHojaRutaInstruccion == id);
        }
    }
}
