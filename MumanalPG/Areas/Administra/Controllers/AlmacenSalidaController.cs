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
    public class AlmacenSalidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlmacenSalidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/AlmacenSalida
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlmacenSalida.ToListAsync());
        }

        // GET: Administra/AlmacenSalida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenSalida = await _context.AlmacenSalida
                .FirstOrDefaultAsync(m => m.IdAlmacenSalida == id);
            if (almacenSalida == null)
            {
                return NotFound();
            }

            return View(almacenSalida);
        }

        // GET: Administra/AlmacenSalida/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/AlmacenSalida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlmacenSalida,IdAlmacenInventario,IdAlmacen,IdBienes,IdDocumentoRespaldo,NumeroDocumento,IdBeneficiario,IdBeneficiarioAlmacenero,FechaSalida,NumeroLote,FechaVencimiento,CantidadSalida,CostoUnitarioBs,SubTotalCompraBs,SubTotalCompraDolares,Concepto,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenSalida almacenSalida)
        {
            if (ModelState.IsValid)
            {
                almacenSalida.FechaRegistro = DateTime.Now;
                almacenSalida.IdEstadoRegistro = '1';

                _context.Add(almacenSalida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacenSalida);
        }

        // GET: Administra/AlmacenSalida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenSalida = await _context.AlmacenSalida.FindAsync(id);
            if (almacenSalida == null)
            {
                return NotFound();
            }
            return View(almacenSalida);
        }

        // POST: Administra/AlmacenSalida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlmacenSalida,IdAlmacenInventario,IdAlmacen,IdBienes,IdDocumentoRespaldo,NumeroDocumento,IdBeneficiario,IdBeneficiarioAlmacenero,FechaSalida,NumeroLote,FechaVencimiento,CantidadSalida,CostoUnitarioBs,SubTotalCompraBs,SubTotalCompraDolares,Concepto,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenSalida almacenSalida)
        {
            if (id != almacenSalida.IdAlmacenSalida)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenSalida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenSalidaExists(almacenSalida.IdAlmacenSalida))
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
            return View(almacenSalida);
        }

        // GET: Administra/AlmacenSalida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenSalida = await _context.AlmacenSalida
                .FirstOrDefaultAsync(m => m.IdAlmacenSalida == id);
            if (almacenSalida == null)
            {
                return NotFound();
            }

            return View(almacenSalida);
        }

        // POST: Administra/AlmacenSalida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almacenSalida = await _context.AlmacenSalida.FindAsync(id);
            _context.AlmacenSalida.Remove(almacenSalida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenSalidaExists(int id)
        {
            return _context.AlmacenSalida.Any(e => e.IdAlmacenSalida == id);
        }
    }
}
