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
    public class CompraContratacionCotizaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraContratacionCotizaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraContratacionCotiza
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraContratacionCotiza.ToListAsync());
        }

        // GET: Administra/CompraContratacionCotiza/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionCotiza = await _context.CompraContratacionCotiza
                .FirstOrDefaultAsync(m => m.IdCompraContratacionCotiza == id);
            if (compraContratacionCotiza == null)
            {
                return NotFound();
            }

            return View(compraContratacionCotiza);
        }

        // GET: Administra/CompraContratacionCotiza/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraContratacionCotiza/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraContratacionCotiza,IdCompraContratacion,FechaCotiza,NumeroVentaPliego,CiteCarta,NumeroCotizacionProveedor,IdBeneficiario,NombreProveedorQueCotiza,FechaEstimadaCompra,FechaLimiteCotizacion,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraContratacionCotiza compraContratacionCotiza)
        {
            if (ModelState.IsValid)
            {
                compraContratacionCotiza.FechaRegistro = DateTime.Now;
                compraContratacionCotiza.IdEstadoRegistro = '1';

                _context.Add(compraContratacionCotiza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraContratacionCotiza);
        }

        // GET: Administra/CompraContratacionCotiza/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionCotiza = await _context.CompraContratacionCotiza.FindAsync(id);
            if (compraContratacionCotiza == null)
            {
                return NotFound();
            }
            return View(compraContratacionCotiza);
        }

        // POST: Administra/CompraContratacionCotiza/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraContratacionCotiza,IdCompraContratacion,FechaCotiza,NumeroVentaPliego,CiteCarta,NumeroCotizacionProveedor,IdBeneficiario,NombreProveedorQueCotiza,FechaEstimadaCompra,FechaLimiteCotizacion,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraContratacionCotiza compraContratacionCotiza)
        {
            if (id != compraContratacionCotiza.IdCompraContratacionCotiza)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraContratacionCotiza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraContratacionCotizaExists(compraContratacionCotiza.IdCompraContratacionCotiza))
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
            return View(compraContratacionCotiza);
        }

        // GET: Administra/CompraContratacionCotiza/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraContratacionCotiza = await _context.CompraContratacionCotiza
                .FirstOrDefaultAsync(m => m.IdCompraContratacionCotiza == id);
            if (compraContratacionCotiza == null)
            {
                return NotFound();
            }

            return View(compraContratacionCotiza);
        }

        // POST: Administra/CompraContratacionCotiza/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraContratacionCotiza = await _context.CompraContratacionCotiza.FindAsync(id);
            _context.CompraContratacionCotiza.Remove(compraContratacionCotiza);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraContratacionCotizaExists(int id)
        {
            return _context.CompraContratacionCotiza.Any(e => e.IdCompraContratacionCotiza == id);
        }
    }
}
