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
    public class CompraCronogramaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompraCronogramaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Administra/CompraCronograma
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompraCronograma.ToListAsync());
        }

        // GET: Administra/CompraCronograma/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCronograma = await _context.CompraCronograma
                .FirstOrDefaultAsync(m => m.IdCompraCronograma == id);
            if (compraCronograma == null)
            {
                return NotFound();
            }

            return View(compraCronograma);
        }

        // GET: Administra/CompraCronograma/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administra/CompraCronograma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCompraCronograma,IdCompraContratacion,IdBeneficiario,EmiteFactura,Descripcion,FechaCronograma,MontoDolares,MontoBs,DescuentoBs,CompraTotalBs,CompraTotalDolares,TipoCambio,Literal,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraCronograma compraCronograma)
        {
            if (ModelState.IsValid)
            {
                compraCronograma.FechaRegistro = DateTime.Now;
                compraCronograma.IdEstadoRegistro = '1';

                _context.Add(compraCronograma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(compraCronograma);
        }

        // GET: Administra/CompraCronograma/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCronograma = await _context.CompraCronograma.FindAsync(id);
            if (compraCronograma == null)
            {
                return NotFound();
            }
            return View(compraCronograma);
        }

        // POST: Administra/CompraCronograma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCompraCronograma,IdCompraContratacion,IdBeneficiario,EmiteFactura,Descripcion,FechaCronograma,MontoDolares,MontoBs,DescuentoBs,CompraTotalBs,CompraTotalDolares,TipoCambio,Literal,IdPoa,IdProceso,IdDocumentoRespaldo,NumeroDocumento,IdEstadoRegistro,IdUsuario,FechaRegistro")] CompraCronograma compraCronograma)
        {
            if (id != compraCronograma.IdCompraCronograma)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compraCronograma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompraCronogramaExists(compraCronograma.IdCompraCronograma))
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
            return View(compraCronograma);
        }

        // GET: Administra/CompraCronograma/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compraCronograma = await _context.CompraCronograma
                .FirstOrDefaultAsync(m => m.IdCompraCronograma == id);
            if (compraCronograma == null)
            {
                return NotFound();
            }

            return View(compraCronograma);
        }

        // POST: Administra/CompraCronograma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compraCronograma = await _context.CompraCronograma.FindAsync(id);
            _context.CompraCronograma.Remove(compraCronograma);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompraCronogramaExists(int id)
        {
            return _context.CompraCronograma.Any(e => e.IdCompraCronograma == id);
        }
    }
}
