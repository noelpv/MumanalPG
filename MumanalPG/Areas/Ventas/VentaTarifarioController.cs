using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MumanalPG.Data;
using MumanalPG.Models.Ventas;

namespace MumanalPG.Areas.Ventas
{
    [Area("Ventas")]
    public class VentaTarifarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentaTarifarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/VentaTarifario
        public async Task<IActionResult> Index()
        {
            return View(await _context.VentaTarifario.ToListAsync());
        }

        // GET: Ventas/VentaTarifario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaTarifario = await _context.VentaTarifario
                .FirstOrDefaultAsync(m => m.IdVentaTarifario == id);
            if (ventaTarifario == null)
            {
                return NotFound();
            }

            return View(ventaTarifario);
        }

        // GET: Ventas/VentaTarifario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/VentaTarifario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdVentaTarifario,Descripcion,IdProcesoNivel2,IdBeneficiarioCategoria,NumeroCuotas,NuemroPeriodos,ValorInicialBs,InteresBs,ValorFinalBs,Porcentaje,IdEstadoRegistro,IdUsuario,FechaRegistro")] VentaTarifario ventaTarifario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaTarifario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaTarifario);
        }

        // GET: Ventas/VentaTarifario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaTarifario = await _context.VentaTarifario.FindAsync(id);
            if (ventaTarifario == null)
            {
                return NotFound();
            }
            return View(ventaTarifario);
        }

        // POST: Ventas/VentaTarifario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdVentaTarifario,Descripcion,IdProcesoNivel2,IdBeneficiarioCategoria,NumeroCuotas,NuemroPeriodos,ValorInicialBs,InteresBs,ValorFinalBs,Porcentaje,IdEstadoRegistro,IdUsuario,FechaRegistro")] VentaTarifario ventaTarifario)
        {
            if (id != ventaTarifario.IdVentaTarifario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaTarifario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaTarifarioExists(ventaTarifario.IdVentaTarifario))
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
            return View(ventaTarifario);
        }

        // GET: Ventas/VentaTarifario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaTarifario = await _context.VentaTarifario
                .FirstOrDefaultAsync(m => m.IdVentaTarifario == id);
            if (ventaTarifario == null)
            {
                return NotFound();
            }

            return View(ventaTarifario);
        }

        // POST: Ventas/VentaTarifario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaTarifario = await _context.VentaTarifario.FindAsync(id);
            _context.VentaTarifario.Remove(ventaTarifario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaTarifarioExists(int id)
        {
            return _context.VentaTarifario.Any(e => e.IdVentaTarifario == id);
        }
    }
}
