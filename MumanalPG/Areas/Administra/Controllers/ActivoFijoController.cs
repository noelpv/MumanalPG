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
    public class ActivoFijoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivoFijoController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Administra/ActivoFijo
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivoFijo.ToListAsync());
        }

        // GET: Administra/ActivoFijo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivoFijo
                .FirstOrDefaultAsync(m => m.IdActivoFijo == id);
            if (activoFijo == null)
            {
                return NotFound();
            }

            return View(activoFijo);
        }

        // GET: Administra/ActivoFijo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/ActivoFijo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdActivoFijo,IdAlmacenInventario,IdBienes,CodigoActivoFijo,CodigoAdministrativo,Descripcion,IdBeneficiario,FechaIncorporacion,Ufv,CostoInicial,DepreciacionAcumuladaInicial,FactorActualizacion,ValorActual,DepreciacionAcumulada,DepreciacionGestion,ValorNeto,TiempoVidaEnAnios,TiempoVidaEnDias,CodigoRube,IdOrganismoFinanciador,IdEstadoActivoFijo,IdEstadoRegistro,IdUsuario,FechaRegistro")] ActivoFijo activoFijo)
        {
            if (ModelState.IsValid)
            {
                activoFijo.FechaRegistro = DateTime.Now;
                activoFijo.IdEstadoRegistro = '1';

                _context.Add(activoFijo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activoFijo);
        }

        // GET: Administra/ActivoFijo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivoFijo.FindAsync(id);
            if (activoFijo == null)
            {
                return NotFound();
            }
            return View(activoFijo);
        }

        // POST: Administra/ActivoFijo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdActivoFijo,IdAlmacenInventario,IdBienes,CodigoActivoFijo,CodigoAdministrativo,Descripcion,IdBeneficiario,FechaIncorporacion,Ufv,CostoInicial,DepreciacionAcumuladaInicial,FactorActualizacion,ValorActual,DepreciacionAcumulada,DepreciacionGestion,ValorNeto,TiempoVidaEnAnios,TiempoVidaEnDias,CodigoRube,IdOrganismoFinanciador,IdEstadoActivoFijo,IdEstadoRegistro,IdUsuario,FechaRegistro")] ActivoFijo activoFijo)
        {
            if (id != activoFijo.IdActivoFijo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activoFijo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivoFijoExists(activoFijo.IdActivoFijo))
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
            return View(activoFijo);
        }

        // GET: Administra/ActivoFijo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activoFijo = await _context.ActivoFijo
                .FirstOrDefaultAsync(m => m.IdActivoFijo == id);
            if (activoFijo == null)
            {
                return NotFound();
            }

            return View(activoFijo);
        }

        // POST: Administra/ActivoFijo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activoFijo = await _context.ActivoFijo.FindAsync(id);
            _context.ActivoFijo.Remove(activoFijo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivoFijoExists(int id)
        {
            return _context.ActivoFijo.Any(e => e.IdActivoFijo == id);
        }
    }
}
