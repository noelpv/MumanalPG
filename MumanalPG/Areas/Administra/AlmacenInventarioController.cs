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
    public class AlmacenInventarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AlmacenInventarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/AlmacenInventario
        public async Task<IActionResult> Index()
        {
            return View(await _context.AlmacenInventario.ToListAsync());
        }

        // GET: Administra/AlmacenInventario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventario
                .FirstOrDefaultAsync(m => m.IdAlmacenInventario == id);
            if (almacenInventario == null)
            {
                return NotFound();
            }

            return View(almacenInventario);
        }

        // GET: Administra/AlmacenInventario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/AlmacenInventario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAlmacenInventario,IdAlmacen,IdBienes,StockIngreso,StockSalida,StockActual,TotalCompraBs,TotalVentaBs,UtilidadBs,TotalCompraDolares,TotalVentaDolares,UtilidadDolares,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenInventario almacenInventario)
        {
            if (ModelState.IsValid)
            {
                almacenInventario.FechaRegistro = DateTime.Now;
                almacenInventario.IdEstadoRegistro = '1';

                _context.Add(almacenInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(almacenInventario);
        }

        // GET: Administra/AlmacenInventario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventario.FindAsync(id);
            if (almacenInventario == null)
            {
                return NotFound();
            }
            return View(almacenInventario);
        }

        // POST: Administra/AlmacenInventario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAlmacenInventario,IdAlmacen,IdBienes,StockIngreso,StockSalida,StockActual,TotalCompraBs,TotalVentaBs,UtilidadBs,TotalCompraDolares,TotalVentaDolares,UtilidadDolares,IdEstadoRegistro,IdUsuario,FechaRegistro")] AlmacenInventario almacenInventario)
        {
            if (id != almacenInventario.IdAlmacenInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(almacenInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlmacenInventarioExists(almacenInventario.IdAlmacenInventario))
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
            return View(almacenInventario);
        }

        // GET: Administra/AlmacenInventario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var almacenInventario = await _context.AlmacenInventario
                .FirstOrDefaultAsync(m => m.IdAlmacenInventario == id);
            if (almacenInventario == null)
            {
                return NotFound();
            }

            return View(almacenInventario);
        }

        // POST: Administra/AlmacenInventario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var almacenInventario = await _context.AlmacenInventario.FindAsync(id);
            _context.AlmacenInventario.Remove(almacenInventario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlmacenInventarioExists(int id)
        {
            return _context.AlmacenInventario.Any(e => e.IdAlmacenInventario == id);
        }
    }
}
