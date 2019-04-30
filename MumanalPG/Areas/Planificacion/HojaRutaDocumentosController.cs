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
    public class HojaRutaDocumentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HojaRutaDocumentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Planificacion/HojaRutaDocumentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.HojaRutaDocumentos.ToListAsync());
        }

        // GET: Planificacion/HojaRutaDocumentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDocumentos = await _context.HojaRutaDocumentos
                .FirstOrDefaultAsync(m => m.IdHojaRutaDocumentos == id);
            if (hojaRutaDocumentos == null)
            {
                return NotFound();
            }

            return View(hojaRutaDocumentos);
        }

        // GET: Planificacion/HojaRutaDocumentos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planificacion/HojaRutaDocumentos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHojaRutaDocumentos,IdHojaRuta,IdDocumentoRespaldo,CiteRespaldo,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaDocumentos hojaRutaDocumentos)
        {
            if (ModelState.IsValid)
            {
                hojaRutaDocumentos.FechaRegistro = DateTime.Now;
                hojaRutaDocumentos.IdEstadoRegistro = '1';

                _context.Add(hojaRutaDocumentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hojaRutaDocumentos);
        }

        // GET: Planificacion/HojaRutaDocumentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDocumentos = await _context.HojaRutaDocumentos.FindAsync(id);
            if (hojaRutaDocumentos == null)
            {
                return NotFound();
            }
            return View(hojaRutaDocumentos);
        }

        // POST: Planificacion/HojaRutaDocumentos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHojaRutaDocumentos,IdHojaRuta,IdDocumentoRespaldo,CiteRespaldo,IdEstadoRegistro,IdUsuario,FechaRegistro,HoraRegistro")] HojaRutaDocumentos hojaRutaDocumentos)
        {
            if (id != hojaRutaDocumentos.IdHojaRutaDocumentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojaRutaDocumentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojaRutaDocumentosExists(hojaRutaDocumentos.IdHojaRutaDocumentos))
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
            return View(hojaRutaDocumentos);
        }

        // GET: Planificacion/HojaRutaDocumentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaRutaDocumentos = await _context.HojaRutaDocumentos
                .FirstOrDefaultAsync(m => m.IdHojaRutaDocumentos == id);
            if (hojaRutaDocumentos == null)
            {
                return NotFound();
            }

            return View(hojaRutaDocumentos);
        }

        // POST: Planificacion/HojaRutaDocumentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojaRutaDocumentos = await _context.HojaRutaDocumentos.FindAsync(id);
            _context.HojaRutaDocumentos.Remove(hojaRutaDocumentos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojaRutaDocumentosExists(int id)
        {
            return _context.HojaRutaDocumentos.Any(e => e.IdHojaRutaDocumentos == id);
        }
    }
}
