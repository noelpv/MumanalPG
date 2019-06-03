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
    public class CompraSolicitudBienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraSolicitudBienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraSolicitudBien
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraSolicitudBien.ToListAsync());
        }

        // GET: Administra/CompraSolicitudBien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitudBien = await _context.CompraSolicitudBien
                .FirstOrDefaultAsync(m => m.IdCompraSolicitudBien == id);
            if (compraSolicitudBien == null)
            {
                return NotFound();
            }

            return View(compraSolicitudBien);
        }

        // GET: Administra/CompraSolicitudBien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraSolicitudBien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraSolicitudBien,IdCompraSolicitud,IdBienes,IdModelo,IdPais,IdUnidadMedida,IdUnidadMedidaEmpaque,CantidadSolicitada,CantidadPorEmpaque,CantidadAprobada,PrecioUnitario,PrecioTotalReferencial,IdTipoMoneda,Observaciones,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraSolicitudBien compraSolicitudBien)
        {
            if (ModelState.IsValid)
            {
                compraSolicitudBien.FechaRegistro = DateTime.Now;
                compraSolicitudBien.IdEstadoRegistro = '1';

                _context.Add(compraSolicitudBien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraSolicitudBien);
        }

        // GET: Administra/CompraSolicitudBien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitudBien = await _context.CompraSolicitudBien.FindAsync(id);
            if (compraSolicitudBien == null)
            {
                return NotFound();
            }
            return View(compraSolicitudBien);
        }

        // POST: Administra/CompraSolicitudBien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraSolicitudBien,IdCompraSolicitud,IdBienes,IdModelo,IdPais,IdUnidadMedida,IdUnidadMedidaEmpaque,CantidadSolicitada,CantidadPorEmpaque,CantidadAprobada,PrecioUnitario,PrecioTotalReferencial,IdTipoMoneda,Observaciones,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraSolicitudBien compraSolicitudBien)
        {
            if (id != compraSolicitudBien.IdCompraSolicitudBien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraSolicitudBien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraSolicitudBienExists(compraSolicitudBien.IdCompraSolicitudBien))
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
            return View(compraSolicitudBien);
        }

        // GET: Administra/CompraSolicitudBien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraSolicitudBien = await _context.CompraSolicitudBien
                .FirstOrDefaultAsync(m => m.IdCompraSolicitudBien == id);
            if (compraSolicitudBien == null)
            {
                return NotFound();
            }

            return View(compraSolicitudBien);
        }

        // POST: Administra/CompraSolicitudBien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraSolicitudBien = await _context.CompraSolicitudBien.FindAsync(id);
            _context.CompraSolicitudBien.Remove(compraSolicitudBien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraSolicitudBienExists(int id)
        {
            return _context.CompraSolicitudBien.Any(e => e.IdCompraSolicitudBien == id);
        }
    }
}
