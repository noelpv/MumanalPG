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
    public class DocumentoRespaldoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocumentoRespaldoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas/DocumentoRespaldo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ventas_DocumentoRespaldo.ToListAsync());
        }

        // GET: Ventas/DocumentoRespaldo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoRespaldo = await _context.Ventas_DocumentoRespaldo
                .FirstOrDefaultAsync(m => m.IdDocumentoRespaldo == id);
            if (documentoRespaldo == null)
            {
                return NotFound();
            }

            return View(documentoRespaldo);
        }

        // GET: Ventas/DocumentoRespaldo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ventas/DocumentoRespaldo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDocumentoRespaldo,IdDocumentoClasificacion,Sigla,Descripcion,IdFrecuenciaUso,IdDocumentoFormato,NumeroCopias,LugarFisicoArchivado,EsUsadoComoRequisito,IdEstadoRegistro,IdUsuario,FechaRegistro")] DocumentoRespaldo documentoRespaldo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documentoRespaldo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(documentoRespaldo);
        }

        // GET: Ventas/DocumentoRespaldo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoRespaldo = await _context.Ventas_DocumentoRespaldo.FindAsync(id);
            if (documentoRespaldo == null)
            {
                return NotFound();
            }
            return View(documentoRespaldo);
        }

        // POST: Ventas/DocumentoRespaldo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDocumentoRespaldo,IdDocumentoClasificacion,Sigla,Descripcion,IdFrecuenciaUso,IdDocumentoFormato,NumeroCopias,LugarFisicoArchivado,EsUsadoComoRequisito,IdEstadoRegistro,IdUsuario,FechaRegistro")] DocumentoRespaldo documentoRespaldo)
        {
            if (id != documentoRespaldo.IdDocumentoRespaldo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documentoRespaldo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoRespaldoExists(documentoRespaldo.IdDocumentoRespaldo))
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
            return View(documentoRespaldo);
        }

        // GET: Ventas/DocumentoRespaldo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var documentoRespaldo = await _context.Ventas_DocumentoRespaldo
                .FirstOrDefaultAsync(m => m.IdDocumentoRespaldo == id);
            if (documentoRespaldo == null)
            {
                return NotFound();
            }

            return View(documentoRespaldo);
        }

        // POST: Ventas/DocumentoRespaldo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var documentoRespaldo = await _context.Ventas_DocumentoRespaldo.FindAsync(id);
            _context.Ventas_DocumentoRespaldo.Remove(documentoRespaldo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoRespaldoExists(int id)
        {
            return _context.Ventas_DocumentoRespaldo.Any(e => e.IdDocumentoRespaldo == id);
        }
    }
}
