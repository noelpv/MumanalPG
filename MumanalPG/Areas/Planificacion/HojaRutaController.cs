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
    public class HojaRutaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HojaRutaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/HojaRuta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Planificacion_HojaRuta.ToListAsync());
        }

        // GET: Planificacion/HojaRuta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRuta = await _context.Planificacion_HojaRuta
                .FirstOrDefaultAsync(m => m.IdHojaRuta == id);
            if (hojaRuta == null)
            {
                return NotFound();
            }

            return View(hojaRuta);
        }

        // GET: Planificacion/HojaRuta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/HojaRuta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHojaRuta,IdUnidadEjecutora,SolicitudCodigo,IdUnidadNivel3,CiteTramite,CiteFecha,NroFojas,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRuta hojaRuta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hojaRuta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hojaRuta);
        }

        // GET: Planificacion/HojaRuta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRuta = await _context.Planificacion_HojaRuta.FindAsync(id);
            if (hojaRuta == null)
            {
                return NotFound();
            }
            return View(hojaRuta);
        }

        // POST: Planificacion/HojaRuta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHojaRuta,IdUnidadEjecutora,SolicitudCodigo,IdUnidadNivel3,CiteTramite,CiteFecha,NroFojas,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRuta hojaRuta)
        {
            if (id != hojaRuta.IdHojaRuta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojaRuta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojaRutaExists(hojaRuta.IdHojaRuta))
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
            return View(hojaRuta);
        }

        // GET: Planificacion/HojaRuta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRuta = await _context.Planificacion_HojaRuta
                .FirstOrDefaultAsync(m => m.IdHojaRuta == id);
            if (hojaRuta == null)
            {
                return NotFound();
            }

            return View(hojaRuta);
        }

        // POST: Planificacion/HojaRuta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojaRuta = await _context.Planificacion_HojaRuta.FindAsync(id);
            _context.Planificacion_HojaRuta.Remove(hojaRuta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojaRutaExists(int id)
        {
            return _context.Planificacion_HojaRuta.Any(e => e.IdHojaRuta == id);
        }
    }
}
