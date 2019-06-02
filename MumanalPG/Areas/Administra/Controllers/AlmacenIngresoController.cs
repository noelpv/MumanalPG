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
    public class AlmacenIngresoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlmacenIngresoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/AlmacenIngreso
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlmacenIngreso.ToListAsync());
        }

        // GET: Administra/AlmacenIngreso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenIngreso = await _context.AlmacenIngreso
                .FirstOrDefaultAsync(m => m.IdAlmacenIngreso == id);
            if (almacenIngreso == null)
            {
                return NotFound();
            }

            return View(almacenIngreso);
        }

        // GET: Administra/AlmacenIngreso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/AlmacenIngreso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlmacenIngreso,IdCompraContratacionBien,IdAlmacenInventario,IdAlmacen,IdBienes,IdDocumentoRespaldo,NumeroDocumento,IdBeneficiario,IdBeneficiarioAlmacenero,FechaIngreso,NumeroLote,FechaVencimiento,CantidadIngreso,CostoUnitarioBs,SubTotalCompraBs,SubTotalCompraDolares,Concepto,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenIngreso almacenIngreso)
        {
            if (ModelState.IsValid)
            {
                almacenIngreso.FechaRegistro = DateTime.Now;
                almacenIngreso.IdEstadoRegistro = '1';

                _context.Add(almacenIngreso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacenIngreso);
        }

        // GET: Administra/AlmacenIngreso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenIngreso = await _context.AlmacenIngreso.FindAsync(id);
            if (almacenIngreso == null)
            {
                return NotFound();
            }
            return View(almacenIngreso);
        }

        // POST: Administra/AlmacenIngreso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlmacenIngreso,IdCompraContratacionBien,IdAlmacenInventario,IdAlmacen,IdBienes,IdDocumentoRespaldo,NumeroDocumento,IdBeneficiario,IdBeneficiarioAlmacenero,FechaIngreso,NumeroLote,FechaVencimiento,CantidadIngreso,CostoUnitarioBs,SubTotalCompraBs,SubTotalCompraDolares,Concepto,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenIngreso almacenIngreso)
        {
            if (id != almacenIngreso.IdAlmacenIngreso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenIngreso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenIngresoExists(almacenIngreso.IdAlmacenIngreso))
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
            return View(almacenIngreso);
        }

        // GET: Administra/AlmacenIngreso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenIngreso = await _context.AlmacenIngreso
                .FirstOrDefaultAsync(m => m.IdAlmacenIngreso == id);
            if (almacenIngreso == null)
            {
                return NotFound();
            }

            return View(almacenIngreso);
        }

        // POST: Administra/AlmacenIngreso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almacenIngreso = await _context.AlmacenIngreso.FindAsync(id);
            _context.AlmacenIngreso.Remove(almacenIngreso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenIngresoExists(int id)
        {
            return _context.AlmacenIngreso.Any(e => e.IdAlmacenIngreso == id);
        }
    }
}
