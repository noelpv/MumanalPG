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
    public class CompraContratacionBienController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraContratacionBienController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraContratacionBien
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraContratacionBien.ToListAsync());
        }

        // GET: Administra/CompraContratacionBien/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionBien = await _context.CompraContratacionBien
                .FirstOrDefaultAsync(m => m.IdCompraContratacionBien == id);
            if (compraContratacionBien == null)
            {
                return NotFound();
            }

            return View(compraContratacionBien);
        }

        // GET: Administra/CompraContratacionBien/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraContratacionBien/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraContratacionBien,IdCompraContratacion,IdBienes,IdUnidadMedida,IdUnidadMedidaEmpaque,CantidadCompra,CantidadRecibida,PrecioUnitarioCompraBs,DescuentoCompraBs,PrecioTotalCompraBs,PrecioTotalCompraDolares,Precio87delTotalBs,IdTipoCambio,IdTipoMoneda,Observaciones,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraContratacionBien compraContratacionBien)
        {
            if (ModelState.IsValid)
            {
                compraContratacionBien.FechaRegistro = DateTime.Now;
                compraContratacionBien.IdEstadoRegistro = '1';

                _context.Add(compraContratacionBien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraContratacionBien);
        }

        // GET: Administra/CompraContratacionBien/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionBien = await _context.CompraContratacionBien.FindAsync(id);
            if (compraContratacionBien == null)
            {
                return NotFound();
            }
            return View(compraContratacionBien);
        }

        // POST: Administra/CompraContratacionBien/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraContratacionBien,IdCompraContratacion,IdBienes,IdUnidadMedida,IdUnidadMedidaEmpaque,CantidadCompra,CantidadRecibida,PrecioUnitarioCompraBs,DescuentoCompraBs,PrecioTotalCompraBs,PrecioTotalCompraDolares,Precio87delTotalBs,IdTipoCambio,IdTipoMoneda,Observaciones,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraContratacionBien compraContratacionBien)
        {
            if (id != compraContratacionBien.IdCompraContratacionBien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraContratacionBien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraContratacionBienExists(compraContratacionBien.IdCompraContratacionBien))
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
            return View(compraContratacionBien);
        }

        // GET: Administra/CompraContratacionBien/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionBien = await _context.CompraContratacionBien
                .FirstOrDefaultAsync(m => m.IdCompraContratacionBien == id);
            if (compraContratacionBien == null)
            {
                return NotFound();
            }

            return View(compraContratacionBien);
        }

        // POST: Administra/CompraContratacionBien/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraContratacionBien = await _context.CompraContratacionBien.FindAsync(id);
            _context.CompraContratacionBien.Remove(compraContratacionBien);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraContratacionBienExists(int id)
        {
            return _context.CompraContratacionBien.Any(e => e.IdCompraContratacionBien == id);
        }
    }
}
