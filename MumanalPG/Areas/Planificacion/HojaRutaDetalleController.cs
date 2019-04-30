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
    public class HojaRutaDetalleController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HojaRutaDetalleController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/HojaRutaDetalle
        public async Task<IActionResult> Index()
        {
            return View(await _context.HojaRutaDetalle.ToListAsync());
        }

        // GET: Planificacion/HojaRutaDetalle/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDetalle = await _context.HojaRutaDetalle
                .FirstOrDefaultAsync(m => m.IdHojaRutaDetalle == id);
            if (hojaRutaDetalle == null)
            {
                return NotFound();
            }

            return View(hojaRutaDetalle);
        }

        // GET: Planificacion/HojaRutaDetalle/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/HojaRutaDetalle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHojaRutaDetalle,IdHojaRuta,IdUnidadEjecutora,IdUnidadEjecutoraDestino,IdUnidadEjecutoraCopia,IdUnidadEjecutoraCoordinar,Idbeneficiario,IdbeneficiarioDestino,IdbeneficiarioCopia,IdbeneficiarioCoordinar,PlazoDias,Proveido,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaDetalle hojaRutaDetalle)
        {
            if (ModelState.IsValid)
            {
                hojaRutaDetalle.FechaRegistro = DateTime.Now;
                hojaRutaDetalle.IdEstadoRegistro = '1';

                _context.Add(hojaRutaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hojaRutaDetalle);
        }

        // GET: Planificacion/HojaRutaDetalle/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDetalle = await _context.HojaRutaDetalle.FindAsync(id);
            if (hojaRutaDetalle == null)
            {
                return NotFound();
            }
            return View(hojaRutaDetalle);
        }

        // POST: Planificacion/HojaRutaDetalle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHojaRutaDetalle,IdHojaRuta,IdUnidadEjecutora,IdUnidadEjecutoraDestino,IdUnidadEjecutoraCopia,IdUnidadEjecutoraCoordinar,Idbeneficiario,IdbeneficiarioDestino,IdbeneficiarioCopia,IdbeneficiarioCoordinar,PlazoDias,Proveido,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaDetalle hojaRutaDetalle)
        {
            if (id != hojaRutaDetalle.IdHojaRutaDetalle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojaRutaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojaRutaDetalleExists(hojaRutaDetalle.IdHojaRutaDetalle))
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
            return View(hojaRutaDetalle);
        }

        // GET: Planificacion/HojaRutaDetalle/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDetalle = await _context.HojaRutaDetalle
                .FirstOrDefaultAsync(m => m.IdHojaRutaDetalle == id);
            if (hojaRutaDetalle == null)
            {
                return NotFound();
            }

            return View(hojaRutaDetalle);
        }

        // POST: Planificacion/HojaRutaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojaRutaDetalle = await _context.HojaRutaDetalle.FindAsync(id);
            _context.HojaRutaDetalle.Remove(hojaRutaDetalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojaRutaDetalleExists(int id)
        {
            return _context.HojaRutaDetalle.Any(e => e.IdHojaRutaDetalle == id);
        }
    }
}
