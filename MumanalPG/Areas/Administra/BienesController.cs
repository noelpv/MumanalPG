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
    public class BienesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BienesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/Bienes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bienes.ToListAsync());
        }

        // GET: Administra/Bienes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienes = await _context.Bienes
                .FirstOrDefaultAsync(m => m.IdBienes == id);
            if (bienes == null)
            {
                return NotFound();
            }

            return View(bienes);
        }

        // GET: Administra/Bienes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/Bienes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBienes,IdPartidaGasto,CodigoBien,Descripcion,Observacion,IdUnidadMedida,IdUnidadMedidaEmpaque,IdModelo,IdPais,CodigoBienAnterior,DescripcionAnterior,IdRotacionBien,NombreArchivo,Foto,Kit,StockMinimo,StockInicial,StockIngreso,StockSalida,StockActual,PrecioReferenciaCompra,PrecioVentaBase,PrecioVentaFinal,TotalAcumuladoCompraBs,TotalAcumuladoVentaBs,TotalUtilidadBs,IdEstadoVigente,IdEstadoRegistro,IdUsuario,FechaRegistro")] Bienes bienes)
        {
            if (ModelState.IsValid)
            {
                bienes.FechaRegistro = DateTime.Now;
                bienes.IdEstadoRegistro = '1';

                _context.Add(bienes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bienes);
        }

        // GET: Administra/Bienes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienes = await _context.Bienes.FindAsync(id);
            if (bienes == null)
            {
                return NotFound();
            }
            return View(bienes);
        }

        // POST: Administra/Bienes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBienes,IdPartidaGasto,CodigoBien,Descripcion,Observacion,IdUnidadMedida,IdUnidadMedidaEmpaque,IdModelo,IdPais,CodigoBienAnterior,DescripcionAnterior,IdRotacionBien,NombreArchivo,Foto,Kit,StockMinimo,StockInicial,StockIngreso,StockSalida,StockActual,PrecioReferenciaCompra,PrecioVentaBase,PrecioVentaFinal,TotalAcumuladoCompraBs,TotalAcumuladoVentaBs,TotalUtilidadBs,IdEstadoVigente,IdEstadoRegistro,IdUsuario,FechaRegistro")] Bienes bienes)
        {
            if (id != bienes.IdBienes)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bienes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BienesExists(bienes.IdBienes))
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
            return View(bienes);
        }

        // GET: Administra/Bienes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bienes = await _context.Bienes
                .FirstOrDefaultAsync(m => m.IdBienes == id);
            if (bienes == null)
            {
                return NotFound();
            }

            return View(bienes);
        }

        // POST: Administra/Bienes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bienes = await _context.Bienes.FindAsync(id);
            _context.Bienes.Remove(bienes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BienesExists(int id)
        {
            return _context.Bienes.Any(e => e.IdBienes == id);
        }
    }
}
